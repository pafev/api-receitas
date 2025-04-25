using ApiReceitas.Domain.Models;
using ApiReceitas.Persistence;

namespace ApiReceitas.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly SqLiteDbContext _dbContext;

        public RecipesService(SqLiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            var recipes = _dbContext.Recipes.ToList();
            return await Task.FromResult(recipes);
        }

        public async Task<Recipe> GetRecipeByIdAsync(Guid id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.RecipeId == id);
            return await Task.FromResult(recipe);
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            _dbContext.Add(recipe);
            await _dbContext.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            var existingRecipe = _dbContext.Recipes.FirstOrDefault(r => r.RecipeId == recipe.RecipeId);
            if (existingRecipe != null)
            {
                existingRecipe.Method = recipe.Method;
                existingRecipe.Ingredients = recipe.Ingredients;
                existingRecipe.RecipeIngredients = recipe.RecipeIngredients;
                await _dbContext.SaveChangesAsync();
            }
            await Task.CompletedTask;
        }

        public async Task DeleteRecipeAsync(Guid id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(r => r.RecipeId == id);
            if (recipe != null)
            {
                _dbContext.Recipes.Remove(recipe);
                await _dbContext.SaveChangesAsync();
            }
            await Task.CompletedTask;
        }
    }
}