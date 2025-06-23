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
        return _context.Recipes.SingleOrDefault(r => r.UserId == userId);
    }

    public Recipe CreateRecipe(Recipe recipe)
    {
        throw new NotImplementedException();
    }
}