using final_project.Models;
using final_project.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace final_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository repository)
        {
            _logger = logger;
            _userRepository = repository;
        }

        // /api/User/:email
        [HttpGet]
        [Route("{email}")]
        public ActionResult<User> GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}