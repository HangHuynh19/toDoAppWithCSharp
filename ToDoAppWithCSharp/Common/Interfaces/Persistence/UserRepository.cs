using ErrorOr;
using ToDoAppWithCSharp.Models;

namespace ToDoAppWithCSharp.Common.Interfaces.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    void IUserRepository.AddUser(ErrorOr<User> user)
    {
        _users.Add(user.Value);
    }

    User? IUserRepository.GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }

    User? IUserRepository.UpdateUserPassword(User user, string newPassword)
    {
        int index = _users.FindIndex(u => u.Email == user.Email);
        return _users[index] = User.Create(user.Email, newPassword, user.UserId, user.CreatedDate, DateTime.UtcNow).Value;
    }
}