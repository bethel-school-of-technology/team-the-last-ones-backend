using final_project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController
{
    private readonly IRecipeRepository _recipeRepository;

    public RecipeController(IRecipeRepository repository)
    {
        _recipeRepository = repository;
    }
}