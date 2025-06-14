using final_project.Models;
using Microsoft.EntityFrameworkCore;

namespace final_project.Migrations;

public class AruchaDb : DbContext
{

    public DbSet<User> users { get; set; }
    public AruchaDb(DbContextOptions<AruchaDb> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.UserName).IsRequired();
        });
    }
}
