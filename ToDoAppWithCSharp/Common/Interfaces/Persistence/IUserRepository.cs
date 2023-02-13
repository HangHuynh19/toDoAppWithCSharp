using ErrorOr;
using ToDoAppWithCSharp.Models;

namespace ToDoAppWithCSharp.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(ErrorOr<User> user);
    User? UpdateUserPassword(User user, string newPassword);
}