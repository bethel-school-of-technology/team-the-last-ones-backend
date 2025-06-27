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

    public IEnumerable<Recipe> GetRecipesByUserId(int userId) 
    {
        return _context.Recipes.Where(r => r.UserId == userId);
    }

    public Recipe CreateRecipe(Recipe recipe)
    {
        _context.Add(recipe);
        _context.SaveChanges();
        return recipe;
    }

    public Recipe? UpdateRecipe(Recipe updateRecipe)
    {
        var orRecipe = _context.Recipes.Find(updateRecipe.RecipeId);
        if (orRecipe != null)
        {
            orRecipe.strCategory = updateRecipe.strCategory;
            orRecipe.strArea = updateRecipe.strArea;
            orRecipe.strTags = updateRecipe.strTags;
            orRecipe.strInstructions = updateRecipe.strInstructions;
            orRecipe.strMealThumb = updateRecipe.strMealThumb;
            orRecipe.strMeal = updateRecipe.strMeal;
            orRecipe.strYoutube = updateRecipe.strYoutube;
            orRecipe.strIngredients1 = updateRecipe.strIngredients1;
            orRecipe.strIngredients2 = updateRecipe.strIngredients2;
            orRecipe.strIngredients3 = updateRecipe.strIngredients3;
            orRecipe.strIngredients4 = updateRecipe.strIngredients4;
            orRecipe.strIngredients5 = updateRecipe.strIngredients5;
            orRecipe.strIngredients6 = updateRecipe.strIngredients6;
            orRecipe.strIngredients7 = updateRecipe.strIngredients7;
            orRecipe.strIngredients8 = updateRecipe.strIngredients8;
            orRecipe.strIngredients9 = updateRecipe.strIngredients9;
            orRecipe.strIngredients10 = updateRecipe.strIngredients10;
            orRecipe.strIngredients11 = updateRecipe.strIngredients11;
            orRecipe.strIngredients12 = updateRecipe.strIngredients12;
            orRecipe.strIngredients13 = updateRecipe.strIngredients13;
            orRecipe.strIngredients14 = updateRecipe.strIngredients14;
            orRecipe.strIngredients15 = updateRecipe.strIngredients15;
            orRecipe.strIngredients16 = updateRecipe.strIngredients16;
            orRecipe.strIngredients17 = updateRecipe.strIngredients17;
            orRecipe.strIngredients18 = updateRecipe.strIngredients18;
            orRecipe.strIngredients19 = updateRecipe.strIngredients19;
            orRecipe.strIngredients20 = updateRecipe.strIngredients20;
            orRecipe.strMeasure1 = updateRecipe.strMeasure1;
            orRecipe.strMeasure2 = updateRecipe.strMeasure2;
            orRecipe.strMeasure3 = updateRecipe.strMeasure3;
            orRecipe.strMeasure4 = updateRecipe.strMeasure4;
            orRecipe.strMeasure5 = updateRecipe.strMeasure5;
            orRecipe.strMeasure6 = updateRecipe.strMeasure6;
            orRecipe.strMeasure7 = updateRecipe.strMeasure7;
            orRecipe.strMeasure8 = updateRecipe.strMeasure8;
            orRecipe.strMeasure9 = updateRecipe.strMeasure9;
            orRecipe.strMeasure10 = updateRecipe.strMeasure10;
            orRecipe.strMeasure11 = updateRecipe.strMeasure11;
            orRecipe.strMeasure12 = updateRecipe.strMeasure12;
            orRecipe.strMeasure13 = updateRecipe.strMeasure13;
            orRecipe.strMeasure14 = updateRecipe.strMeasure14;
            orRecipe.strMeasure15 = updateRecipe.strMeasure15;
            orRecipe.strMeasure16 = updateRecipe.strMeasure16;
            orRecipe.strMeasure17 = updateRecipe.strMeasure17;
            orRecipe.strMeasure18 = updateRecipe.strMeasure18;
            orRecipe.strMeasure19 = updateRecipe.strMeasure19;
            orRecipe.strMeasure20 = updateRecipe.strMeasure20;
            _context.SaveChanges();
        }
        return orRecipe;
    }

    public void DeleteRecipeById(int recipeId)
    {
        var recipe = _context.Recipes.Find(recipeId);
        if (recipe != null)
        {
            _context.Recipes.Remove(recipe);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Recipe> GetRecipeById(int recipeId)
    {
        return _context.Recipes.Where(r => r.RecipeId == recipeId);
    }
}