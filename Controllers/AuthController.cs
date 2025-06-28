using final_project.Models;
using final_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController: Controller {
	private readonly IAuthService _authService;

	public AuthController(IAuthService authService) {
		_authService = authService;
	}

	[HttpPost]
	[Route("register")]
	public ActionResult CreateUser(RegisterUserDto regUserDto) {
		if (regUserDto == null || !ModelState.IsValid) {
			return BadRequest("Something wrong with the payload");
		}

		User user = new User {
			Email = regUserDto.email,
			UserName = regUserDto.userName,
			Password = regUserDto.password
		};

		if (_authService.RegisterUser(user) == null) {
			return Conflict("User already exists");
		} else {
			return NoContent();
		}
	}

	[HttpGet]
	[Route("login")]
	public ActionResult<string> Login(string email, string password) {
		if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password)) {
			return BadRequest("Empty email or password");
		}

		string token = _authService.Login(email, password);

		if (string.IsNullOrWhiteSpace(token)) {
			return Unauthorized();
		}

		return Ok(token);
	}
}