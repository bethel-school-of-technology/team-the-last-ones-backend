using System.ComponentModel.DataAnnotations;

namespace final_project.Models;

public class RegisterUserDto {
	[EmailAddress]
	[Required]
	public string email { get; set; } = String.Empty;
	[Required]
	public string userName { get; set; } = String.Empty;
	[Required]
	public string password { get; set; } = String.Empty;
}