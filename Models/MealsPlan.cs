namespace final_project.Models;

public class MealsPlan{
    public int MealsPlanId { get; set; }
    public int UserId;
    public string TimeOfDay { get; set; } = String.Empty;
    public DateTime Date { get; set; }
    public int MealId { get; set; }
}