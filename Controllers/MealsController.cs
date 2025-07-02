using final_project.Models;
using final_project.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [Authorize]
        [HttpPost]
        [Route("create")]
        public ActionResult CreateMeals(MealsPlanDtoRx mealDto)
        {
            if (mealDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            MealsPlan meal = new MealsPlan {
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
        [Authorize]
        [HttpGet]
        [Route("{userId:int}")]
        public ActionResult<IEnumerable<MealsPlanDtoTx>> GetMealsByUserId(int userId)
        {
            return Ok(_mealsRepository.GetMealsByUserId(userId));
        }

        // /api/meals/MealId
        [Authorize]
        [HttpGet]
        [Route("mealId{MealId:int}")]
        public ActionResult<MealsPlanDtoTx> GetMealById(int MealId)
        {
            var meal = _mealsRepository.GetMealById(MealId);
            if (meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        // /api/meals/update
        [Authorize]
        [HttpPut]
        [Route("{update:int}")]
        public ActionResult<MealsPlanDtoRx> UpdateMeal(MealsPlan meal)
        {
            if (!ModelState.IsValid || meal == null)
            {
                return BadRequest();
            }
            return Ok(_mealsRepository.UpdateMeal(meal));
        }

        // /api/meals/delete
        [Authorize]
        [HttpDelete]
        [Route("delete{mealPlanId:int}")]
        public ActionResult DeleteMeal(int mealPlanId)
        {
            _mealsRepository.DeleteMealByMealPlanId(mealPlanId);
            return NoContent();
        }
    }
}
