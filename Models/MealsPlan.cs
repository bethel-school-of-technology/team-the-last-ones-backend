namespace final_project.Models;

public class MealsPlan{
    public int MealsPlanId { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public string TimeOfDay { get; set; } = String.Empty;
    public DateTime Date { get; set; }
    public int MealId { get; set; }
}