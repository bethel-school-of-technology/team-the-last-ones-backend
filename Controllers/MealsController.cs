using final_project.Models;
using final_project.Repositories;
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
        [HttpGet]
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
    }
}
