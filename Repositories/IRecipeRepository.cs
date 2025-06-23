using final_project.Models;

namespace final_project.Repositories;

public interface IRecipeRepository 
{
    Recipe? GetRecipeByUserId(int userId) ;
    Recipe CreateRecipe(Recipe recipe);
}