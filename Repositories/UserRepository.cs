using final_project.Models;
using final_project.Migrations;

namespace final_project.Repositories;

public class UserRepository : IUserRepository
{

    private static AruchaDb _context;

    public UserRepository(AruchaDb context)
    {
        _context = context;
    }
    public User? GetUserByEmail(string email)
    {
        return _context.users.SingleOrDefault(c => c.Email == email);
    }

    public User CreateUser(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
        return user;
    }


}