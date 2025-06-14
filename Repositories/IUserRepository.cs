using final_project.Models;

namespace final_project.Repositories;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    User CreateUser(User user);
}