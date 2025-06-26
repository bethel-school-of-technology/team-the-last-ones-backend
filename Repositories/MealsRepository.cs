using final_project.Models;
using final_project.Migrations;

namespace final_project.Repositories;

public class MealsRepository : IMealsRepository
{
    private readonly AruchaDb _context;

    public MealsRepository(AruchaDb context)
    {
        _context = context;
    }

    public MealsPlan CreateMeals(MealsPlan meal)
    {
        _context.Add(meal);
        _context.SaveChanges();
        return meal;
    }
}