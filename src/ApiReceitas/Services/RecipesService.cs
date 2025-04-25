using ApiReceitas.Domain.Models;

namespace ApiReceitas.Services
{
    public class RecipesService : IRecipesService
{
    private readonly List<Recipe> _recipes = new List<Recipe>();

    public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
    {
        return await Task.FromResult(_recipes);
    }

    public async Task<Recipe?> GetRecipeByIdAsync(Guid id)
    {
        return await Task.FromResult(_recipes.FirstOrDefault(r => r.RecipeId == id));
    }

    public async Task AddRecipeAsync(Recipe recipe)
    {
        _recipes.Add(recipe);
        await Task.CompletedTask;
    }

    public async Task UpdateRecipeAsync(Recipe recipe)
    {
        var existingRecipe = _recipes.FirstOrDefault(r => r.RecipeId == recipe.RecipeId);
        if (existingRecipe != null)
        {
            existingRecipe.Method = recipe.Method;
            existingRecipe.Ingredients = recipe.Ingredients;
        }
        await Task.CompletedTask;
    }

    public async Task DeleteRecipeAsync(Guid id)
    {
        var recipe = _recipes.FirstOrDefault(r => r.RecipeId == id);
        if (recipe != null)
        {
            _recipes.Remove(recipe);
        }
        await Task.CompletedTask;
    }
}
}