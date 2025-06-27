using final_project.Models;
using final_project.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace final_project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : Controller
{
    private readonly IRecipeRepository _recipeRepository;

    public RecipeController(IRecipeRepository repository)
    {
        _recipeRepository = repository;
    }

    [HttpPost]
    public ActionResult CreateRecipe(Recipe recipe)
    {
        // throw new NotImplementedException();
        if (recipe == null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        if (_recipeRepository.GetRecipesByUserId(recipe.UserId) != null)
        {
            return BadRequest();
        }

        _recipeRepository.CreateRecipe(recipe);
        return NoContent();
    }

    [HttpGet]
    [Route("UserId:int/{Id}")]
    public ActionResult<IEnumerable<Recipe>> GetRecipesById(int Id)
    {
        return Ok(_recipeRepository.GetRecipesByUserId(Id));
    }

    [HttpPut]
    [Route("{recipeId}")]
    public ActionResult<Recipe> UpdateRecipe(Recipe recipe)
    {
        if (!ModelState.IsValid || recipe == null)
        {
            return BadRequest();
        }
        return Ok(_recipeRepository.UpdateRecipe(recipe));
    }

    [HttpDelete]
    [Route("recipeId")]
    public ActionResult DeleteRecipe(int recipeId)
    {
        _recipeRepository.DeleteRecipeById(recipeId);
        return NoContent();
    }

    [HttpGet]
    [Route("{recipeId}")]
    public ActionResult<Recipe> GetRecipeById(int recipeId)
    {
        var recipe = _recipeRepository.GetRecipeById(recipeId);
        if (recipe == null)
        {
            return NotFound();
        }
        return Ok(recipe);
    }
    

}

