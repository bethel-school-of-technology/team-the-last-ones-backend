using final_project.Models;

namespace final_project.Repositories;

public interface IMealsRepository
{
    MealsPlan? CreateMeals(MealsPlan meal);
    IEnumerable<MealsPlan> GetMealsByUserId(int userId);
    MealsPlan? GetMealById(int mealId);
    MealsPlan? UpdateMeal(MealsPlan updateMeal);
    void DeleteMealByMealPlanId(int mealPlanId);
}