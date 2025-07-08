namespace final_project.Models;

public class MealsPlanDtoRx{
    public int UserId { get; set; }
    public string TimeOfDay { get; set; } = String.Empty; // Breakfast, Lunch, or Dinner
    public DateTime Date { get; set; } // Day of week
    public int IdMeal { get; set; } // External MealsDB id for the recipe
}