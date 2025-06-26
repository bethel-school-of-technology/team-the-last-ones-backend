using final_project.Models;
using final_project.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace final_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealsController : Controller
    {
        private readonly ILogger<MealsController> _logger;
        private readonly IMealsRepository _mealsRepository;

        public MealsController(ILogger<MealsController> logger, IMealsRepository repository)
        {
            _logger = logger;
            _mealsRepository = repository;
        }

        // /api/meals/create
        [HttpPost]
        [Route("create")]
        public ActionResult CreateMeals(MealsPlan meal)
        {
            if (meal == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _mealsRepository.CreateMeals(meal);
            return NoContent();
        }

        // /api/mealsUserId
        [HttpGet]
        [Route("{UserId}")]
        public ActionResult<IEnumerable<MealsPlan>> GetMealsByUserId(int userId)
        {
            return Ok(_mealsRepository.GetMealsByUserId(userId));
        }

        // /api/meals/MealId
        [HttpGet]
        [Route("mealId{MealId}")]
        public ActionResult<MealsPlan> GetMealById(int MealId)
        {
            var meal = _mealsRepository.GetMealsByUserId(MealId);
            if (meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        // /api/meals/update
        [HttpPut]
        [Route("update:int")]
        public ActionResult<MealsPlan> UpdateMeal(MealsPlan meal)
        {
            if (!ModelState.IsValid || meal == null)
            {
                return BadRequest();
            }
            return Ok(_mealsRepository.UpdateMeal(meal));
        }
    }
}
