using final_project.Migrations;
using final_project.Models;

namespace final_project.Repositories;

public class RecipeRepository: IRecipeRepository
{
    private readonly AruchaDb _context;

    public RecipeRepository(AruchaDb context) 
    {
        _context = context;
    }

    public Recipe? GetRecipeByUserId(int userId) 
    {
        throw new NotImplementedException();
    }

    public Recipe CreateRecipe(Recipe recipe)
    {
        throw new NotImplementedException();
    }
}