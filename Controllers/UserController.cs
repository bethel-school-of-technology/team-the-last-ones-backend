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

        [HttpGet]
        [Route("userId{userId:int}")]
        public ActionResult<UpdateUserDto> GetUserByUserId(int userId)
        {
            var user = _userRepository.GetUserByUserId(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("{UserId:int}")]
        public ActionResult UpdateUser(UpdateUserDto user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest();
            }
            return Ok(_userRepository.UpdateUser(user));
        }

        [HttpDelete]
        [Route("delete{userId:int}")]
        public ActionResult DeleteUserById(int userId)
        {
            _userRepository.DeleteUserById(userId);
            return NoContent();
        }
    }
}