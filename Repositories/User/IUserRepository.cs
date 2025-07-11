using final_project.Models;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace final_project.Repositories;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    User? GetUserByUserName(string username);

    User? GetUserByUserId(int userId);

    User? CreateUser(User user);

    User? UpdateUser(UpdateUserDto user);

    void DeleteUserById(int userId);
}