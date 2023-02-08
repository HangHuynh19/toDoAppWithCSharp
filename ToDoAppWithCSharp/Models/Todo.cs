
using System.Text.Json.Serialization;
using ErrorOr;
using ToDoAppWithCSharp.Contracts.Todo;
using ToDoAppWithCSharp.Contracts.Util;
using ToDoAppWithCSharp.ServiceErrors;

namespace ToDoAppWithCSharp.Models;

public class Todo
{
    public const int MinNameLength = 3;
    public const int MaxNameLength = 260;
    public Guid TodoID { get; }
    public string Name { get; }
    public string Description { get; }
    public Guid UserID { get; }
    public DateTime CreatedDate { get; }
    public DateTime UpdatedDate { get; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status Status { get; }

    private Todo(Guid id, string name, string description, Guid userID, DateTime createdDated, DateTime updatedDate, Status status)
    {
        TodoID = id;
        Name = name;
        Description = description;
        UserID = userID;
        CreatedDate = createdDated;
        UpdatedDate = updatedDate;
        Status = status;

    }

    public static ErrorOr<Todo> Create(
        string name,
        string description,
        Guid userID,
        Status status,
        Guid? id = null,
        DateTime? createdDate = null)
    {
        List<Error> errors = new();

        if (name.Length is < MinNameLength or > MaxNameLength)
        {
            errors.Add(Errors.Todo.InvalidTodoName);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Todo(
            id ?? Guid.NewGuid(),
            name,
            description,
            userID,
            createdDate ?? DateTime.UtcNow,
            DateTime.UtcNow,
            status
        );
    }

    public static ErrorOr<Todo> From(CreateTodoRequest request)
    {
        Status status = ConvertFromIntToEnum(request.Status);

        return Create(
            request.Name,
            request.Description,
            request.UserID,
            status
        );
    }

    public static ErrorOr<Todo> From(Guid id, UpdateTodoRequest request)
    {
        Status status = ConvertFromIntToEnum(request.Status);

        return Create(
            request.Name,
            request.Description,
            request.UserID,
            status,
            id,
            request.CreatedDate
        );
    }

    private static Status ConvertFromIntToEnum(int num)
    {
        Status status = Status.NotStarted;

        foreach (int i in Enum.GetValues(typeof(Status)))
        {
            if (num == i)
            {
                status = (Status)i;
            }
        }

        return status;
    }
}
