using final_project.Models;

namespace final_project.Repositories;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    User? GetUserByUserName(string username);

    User? CreateUser(User user);

    User? UpdateUser(User user);
}