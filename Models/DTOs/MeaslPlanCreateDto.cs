namespace final_project.Models;

public class MealsPlanCreateDto{
    public int UserId { get; set; }
    public string TimeOfDay { get; set; } = String.Empty; // Breakfast, Lunch, or Dinner
    public DateTime Date { get; set; } // Day of week
    public int idMeal { get; set; } // External MealsDB id for the recipe
    public string Thumb { get; set; } // Meal thumbnail
    public string MealName { get; set; } // Actual name of the meal
}