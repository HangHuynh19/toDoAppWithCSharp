namespace ToDoAppWithCSharp.Domain.Entities;

public class User
{
    public Guid UserId { get; } = Guid.NewGuid();
    public string Email { get; } = null!;
    public string Password { get; } = null!;
    public DateTime CreatedDate { get; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; } = DateTime.UtcNow;
}