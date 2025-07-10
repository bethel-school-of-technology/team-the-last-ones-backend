using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace final_project.Models;

public class UpdateUserDto {
    public int UserId {get; set;}

	[EmailAddress]
	[Required]
	public string Email { get; set; } = String.Empty;
	[Required]
	public string UserName { get; set; } = String.Empty;
}