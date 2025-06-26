using Bcrypt = BCrypt.Net.BCrypt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using final_project.Models;
using final_project.Repositories;

namespace final_project.Services;

public class AuthService: IAuthService {
    private IUserRepository _userRepo;
    private IConfiguration _config;

    public AuthService(IUserRepository userRepository, IConfiguration config) {
        _userRepo = userRepository;
        _config = config;
    }

    public User RegisterUser(User user) {
        string passwordHash = Bcrypt.HashPassword(user.Password);
        user.Password = passwordHash;

        _userRepo.CreateUser(user);
        return user;
    }

    public string Login(string email, string password) {
        // throw new NotImplementedException();
        User? user = _userRepo.GetUserByEmail(email);
        bool verified = false;

        if (user != null) {
            verified = Bcrypt.Verify(password, user.Password);
        }

        if (user == null) {
            return String.Empty;
        }

        return BuildToken(user);
    }

    private string BuildToken(User user) {
        string secret = _config.GetValue<String>("TokenSecret") ?? throw new Exception("Failed to load JWT secret!");
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.PreferredUsername, user.UserName)
        };

        SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = signingCredentials
        };

        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
        SecurityToken token = handler.CreateToken(descriptor);
        string encodedToken = handler.WriteToken(token);

        return encodedToken;
    }
}