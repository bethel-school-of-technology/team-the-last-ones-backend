using Bcrypt = BCrypt.Net.BCrypt;

using final_project.Models;
using final_project.Repositories;

namespace final_project.Services;

public class AuthService: IAuthService {
    private IUserRepository _userRepo;

    public AuthService(IUserRepository userRepository) {
        _userRepo = userRepository;
    }

    public User RegisterUser(User user) {
        string passwordHash = Bcrypt.HashPassword(user.Password);
        user.Password = passwordHash;

        _userRepo.CreateUser(user);
        return user;
    }

    public string Login(string email, string password) {
        throw new NotImplementedException();
    }
}