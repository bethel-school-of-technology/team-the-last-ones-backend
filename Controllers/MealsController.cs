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
        public ActionResult CreateMeals(MealsPlanDto mealDto)
        {
            if (mealDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            MealsPlan meal = new MealsPlan {
                MealsPlanId = mealDto.MealsPlanId,
                UserId = mealDto.UserId,
                TimeOfDay = mealDto.TimeOfDay,
                Date = mealDto.Date,
                MealId = mealDto.idMeal
            };

            if (_mealsRepository.CreateMeals(meal) != null) {
                return NoContent();
            } else {
                return BadRequest("The user for this meal does not exist. Bad UserId.");
            }
        }

        // /api/mealsUserId
        [HttpGet]
        [Route("{UserId}")]
        public ActionResult<IEnumerable<MealsPlanDto>> GetMealsByUserId(int userId)
        {
            return Ok(_mealsRepository.GetMealsByUserId(userId));
        }

        // /api/meals/MealId
        [HttpGet]
        [Route("mealId{MealId}")]
        public ActionResult<MealsPlanDto> GetMealById(int MealId)
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
        public ActionResult<MealsPlanDto> UpdateMeal(MealsPlan meal)
        {
            if (!ModelState.IsValid || meal == null)
            {
                return BadRequest();
            }
            return Ok(_mealsRepository.UpdateMeal(meal));
        }

        // /api/meals/delete
        [HttpDelete]
        [Route("delete{mealsPlanId}")]
        public ActionResult DeleteMeal(int mealPlanId)
        {
            _mealsRepository.DeleteMealByMealPlanId(mealPlanId);
            return NoContent();
        }
    }
}
