using ApiReceitas.Domain.Models;
using ApiReceitas.Persistence;

namespace ApiReceitas.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly SqLiteDbContext _dbContext;

        public IngredientsService(SqLiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
        {
            var ingredients = _dbContext.Ingredients.ToList();
            return await Task.FromResult(ingredients);
        }

        public async Task<Ingredient> GetIngredientByIdAsync(Guid id)
        {
            var ingredient = _dbContext.Ingredients.FirstOrDefault(i => i.IngredientId == id);
            return await Task.FromResult(ingredient);
        }

        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            _dbContext.Ingredients.Add(ingredient);
            await _dbContext.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            var existingIngredient = _dbContext.Ingredients.FirstOrDefault(i => i.IngredientId == ingredient.IngredientId);
            if (existingIngredient != null)
            {
                existingIngredient.Name = ingredient.Name;
                existingIngredient.Unit = ingredient.Unit;
                await _dbContext.SaveChangesAsync();
            }
            await Task.CompletedTask;
        }

        public async Task DeleteIngredientAsync(Guid id)
        {
            var ingredient = _dbContext.Ingredients.FirstOrDefault(i => i.IngredientId == id);
            if (ingredient != null)
            {
                _dbContext.Ingredients.Remove(ingredient);
                await _dbContext.SaveChangesAsync();
            }
            await Task.CompletedTask;
        }
    }
}