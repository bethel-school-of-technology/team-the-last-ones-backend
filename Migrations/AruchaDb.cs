using final_project.Models;
using Microsoft.EntityFrameworkCore;

namespace final_project.Migrations;

public class AruchaDb : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }

    public DbSet<MealsPlan> Meals { get; set; }
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

        modelBuilder.Entity<Recipe>(entity => {
            entity.HasKey(e => e.RecipeId);
            entity.Property(e => e.strMeal);
            entity.Property(e => e.strCategory);
            entity.Property(e => e.strArea);
            entity.Property(e => e.strInstructions);
            entity.Property(e => e.strMealThumb);
            entity.Property(e => e.strTags);
            entity.Property(e => e.strYoutube);
            entity.Property(e => e.strIngredients1);
            entity.Property(e => e.strIngredients2);
            entity.Property(e => e.strIngredients3);
            entity.Property(e => e.strIngredients4);
            entity.Property(e => e.strIngredients5);
            entity.Property(e => e.strIngredients6);
            entity.Property(e => e.strIngredients7);
            entity.Property(e => e.strIngredients8);
            entity.Property(e => e.strIngredients9);
            entity.Property(e => e.strIngredients10);
            entity.Property(e => e.strIngredients11);
            entity.Property(e => e.strIngredients12);
            entity.Property(e => e.strIngredients13);
            entity.Property(e => e.strIngredients14);
            entity.Property(e => e.strIngredients15);
            entity.Property(e => e.strIngredients16);
            entity.Property(e => e.strIngredients17);
            entity.Property(e => e.strIngredients18);
            entity.Property(e => e.strIngredients19);
            entity.Property(e => e.strIngredients20);
            entity.Property(e => e.strMeasure1);
            entity.Property(e => e.strMeasure2);
            entity.Property(e => e.strMeasure3);
            entity.Property(e => e.strMeasure4);
            entity.Property(e => e.strMeasure5);
            entity.Property(e => e.strMeasure6);
            entity.Property(e => e.strMeasure7);
            entity.Property(e => e.strMeasure8);
            entity.Property(e => e.strMeasure9);
            entity.Property(e => e.strMeasure10);
            entity.Property(e => e.strMeasure11);
            entity.Property(e => e.strMeasure12);
            entity.Property(e => e.strMeasure13);
            entity.Property(e => e.strMeasure14);
            entity.Property(e => e.strMeasure15);
            entity.Property(e => e.strMeasure16);
            entity.Property(e => e.strMeasure17);
            entity.Property(e => e.strMeasure18);
            entity.Property(e => e.strMeasure19);
            entity.Property(e => e.strMeasure20);
        });

        modelBuilder.Entity<MealsPlan>(entity =>
        {
            entity.HasKey(e => e.MealsPlanId);
            entity.Property(e => e.UserId);
            entity.Property(e => e.TimeOfDay);
            entity.Property(e => e.Date);
            entity.Property(e => e.MealId);
        });

        modelBuilder.Entity<User>()
            .HasMany(u => u.Recipes)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId);

        modelBuilder.Entity<User>()
            .HasMany(m => m.MealPlans)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId);
    }
}
