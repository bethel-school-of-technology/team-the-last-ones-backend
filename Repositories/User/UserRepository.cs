using final_project.Models;
using final_project.Migrations;

namespace final_project.Repositories;

public class UserRepository : IUserRepository
{

    private readonly AruchaDb _context;

    public UserRepository(AruchaDb context)
    {
        _context = context;
    }
    public User? GetUserByEmail(string email)
    {
        return _context.Users.SingleOrDefault(c => c.Email == email);
    }

    public User? GetUserByUserName(string username)
    {
        return _context.Users.SingleOrDefault(c => c.UserName == username);
    }

    public User? CreateUser(User user)
    {
        if (
            _context.Users.Any(u => u.Email == user.Email) ||
            _context.Users.Any(u => u.UserName == user.UserName)
        ) { return null; }

        _context.Add(user);
        _context.SaveChanges();
        return user;
    }
}