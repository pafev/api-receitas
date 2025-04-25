using ApiReceitas.Domain.Models;

namespace ApiReceitas.Services
{
    public class IngredientsService : IIngredientsService
{
    private readonly List<Ingredient> _ingredients = new List<Ingredient>();

    public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
    {
        return await Task.FromResult(_ingredients);
    }

    public async Task<Ingredient?> GetIngredientByIdAsync(Guid id)
    {
        return await Task.FromResult(_ingredients.FirstOrDefault(i => i.IngredientId == id));
    }

    public async Task AddIngredientAsync(Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
        await Task.CompletedTask;
    }

    public async Task UpdateIngredientAsync(Ingredient ingredient)
    {
        var existingIngredient = _ingredients.FirstOrDefault(i => i.IngredientId == ingredient.IngredientId);
        if (existingIngredient != null)
        {
            existingIngredient.Nome = ingredient.Nome;
            existingIngredient.Unit = ingredient.Unit;
        }
        await Task.CompletedTask;
    }

    public async Task DeleteIngredientAsync(Guid id)
    {
        var ingredient = _ingredients.FirstOrDefault(i => i.IngredientId == id);
        if (ingredient != null)
        {
            _ingredients.Remove(ingredient);
        }
        await Task.CompletedTask;
    }
}
}