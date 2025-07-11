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

    public User? GetUserByUserId(int userId)
    {
        return _context.Users.SingleOrDefault(c => c.UserId == userId);
    }

    public User? GetUserByUserName(string username)
    {
        return _context.Users.SingleOrDefault(c => c.UserName == username);
    }

    public User? CreateUser(User user)
    {
        if (!UserInDatabase(user))
        {
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }
        return null;
    }

    private bool UserInDatabase(User user)
    {
        return _context.Users.Any(u => u.Email == user.Email) || _context.Users.Any(u => u.UserName == user.UserName);
    }

    public User? UpdateUser(UpdateUserDto user)
    {
        var orUser = _context.Users.Find(user.UserId);
        if (orUser != null)
        {
            orUser.Email = user.Email;
            orUser.UserName = user.UserName;
            _context.SaveChanges();
        }
        return orUser;
    }

    public void DeleteUserById(int userId)
    {
        var user = _context.Users.Find(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}