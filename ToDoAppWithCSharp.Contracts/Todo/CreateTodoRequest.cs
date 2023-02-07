using ToDoAppWithCSharp.Contracts.Util;

namespace ToDoAppWithCSharp.Contracts.Todo;

public record CreateTodoRequest(
    // - Id: Unique identifier
    // - Name: Name of the todo item
    // - Description (optional): Description of the toto item
    // - User id: Id of the user who owns this todo item
    // - Created timestamp: When the item is created
    // - Updated timestamp: When the item is last updated
    // - Status: An enum of either: NotStarted, OnGoing, Completed
    string Name,
    string Description,
    int UserID,
    //DateTime CreatedDate, 
    //DateTime UpdatedDate,
    int Status
);