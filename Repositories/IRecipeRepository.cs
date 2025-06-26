using final_project.Models;

namespace final_project.Repositories;

public interface IRecipeRepository
{
    IEnumerable<Recipe> GetRecipesByUserId(int userId);
    Recipe CreateRecipe(Recipe recipe);
    Recipe? UpdateRecipe(Recipe updateRecipe);
    void DeleteRecipeById(int recipeId);
    IEnumerable<Recipe> GetRecipeById(int recipeId);
}