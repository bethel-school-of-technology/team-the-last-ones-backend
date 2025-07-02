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
        public ActionResult CreateMeals(MealsPlanCreateDto mealDto)
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
        [HttpGet]
        [Route("{userId:int}")]
        public ActionResult<IEnumerable<MealsPlanResponseDto>> GetMealsByUserId(int userId)
        {
            return Ok(_mealsRepository.GetMealsByUserId(userId));
        }

        // /api/meals/MealId
        [HttpGet]
        [Route("mealId{MealId:int}")]
        public ActionResult<MealsPlanResponseDto> GetMealById(int MealId)
        {
            var meal = _mealsRepository.GetMealById(MealId);
            if (meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        // /api/meals/update
        [HttpPut]
        [Route("update")]
        public ActionResult<MealsPlanResponseDto> UpdateMeal(MealsPlanUpdateDto updateMealDto)
        {
            if (!ModelState.IsValid || updateMealDto == null)
            {
                return BadRequest();
            }

            MealsPlan? originalMeal = _mealsRepository.GetMealById(updateMealDto.MealsPlanId);
            if (originalMeal == null) {
                return NotFound();
            }

            originalMeal.UserId = updateMealDto.UserId;
            originalMeal.TimeOfDay = updateMealDto.TimeOfDay;
            originalMeal.MealId = updateMealDto.idMeal;

            _mealsRepository.UpdateMeal(originalMeal);

            MealsPlanResponseDto returnMeal = new MealsPlanResponseDto {
                MealsPlanId = originalMeal.MealsPlanId,
                UserId = originalMeal.UserId,
                TimeOfDay = originalMeal.TimeOfDay,
                Date = originalMeal.Date,
                idMeal = originalMeal.MealId
            };

            return Ok(returnMeal);
        }

        // /api/meals/delete
        [HttpDelete]
        [Route("delete{mealPlanId:int}")]
        public ActionResult DeleteMeal(int mealPlanId)
        {
            _mealsRepository.DeleteMealByMealPlanId(mealPlanId);
            return NoContent();
        }
    }
}
