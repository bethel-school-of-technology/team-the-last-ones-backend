using final_project.Models;

namespace final_project.Services;

public interface IAuthService {
    User? RegisterUser(User user);
    string Login(string email, string password);
}