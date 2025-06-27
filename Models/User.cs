using System.ComponentModel.DataAnnotations;

namespace final_project.Models;

public class User
{
    public int UserId { get; set; }

    [Required]
    public string UserName { get; set; } = String.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = String.Empty;

    [Required]
    public string Password { get; set; } = String.Empty;

    public List<Recipe> Recipes { get; set; } = new List<Recipe>();
    public List<MealsPlan> MealPlans { get; set; } = new List<MealsPlan>();
}