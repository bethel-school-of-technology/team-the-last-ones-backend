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

    public MealsPlan? CreateMeals(MealsPlan meal)
    {
        if (!_context.Users.Any(u => u.UserId == meal.UserId)) {
            return null;
        }
        _context.Add(meal);
        _context.SaveChanges();
        return meal;
    }

    public IEnumerable<MealsPlan> GetMealsByUserId(int userId)
    {
        return _context.Meals.Where(m => m.UserId == userId);
    }

    public MealsPlan? GetMealById(int mealId)
    {
        return _context.Meals.SingleOrDefault(m => m.MealsPlanId == mealId);
    }

    public MealsPlan? UpdateMeal(MealsPlan updateMeal)
    {
        var orMeal = _context.Meals.Find(updateMeal.MealsPlanId);
        if (orMeal != null)
        {
            orMeal.MealId = updateMeal.MealId;
            orMeal.Date = updateMeal.Date;
            orMeal.TimeOfDay = updateMeal.TimeOfDay;
            _context.SaveChanges();
        }
        return orMeal;
    }

    public void DeleteMealByMealPlanId(int mealPlanId)
    {
        var meal = _context.Meals.Find(mealPlanId);
        if (meal != null)
        {
            _context.Meals.Remove(meal);
            _context.SaveChanges();
        }
    }
}