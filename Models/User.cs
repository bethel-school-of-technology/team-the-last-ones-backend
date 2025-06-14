using System.ComponentModel.DataAnnotations;

namespace final_project.models;

public class User
{
    public int UserId { get; set; }

    [Required]
    public string? UserName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}