using ApiReceitas.Domain.Models;

namespace ApiReceitas.Services
{
    public interface IIngredientsService
{
    Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();
    Task<Ingredient> GetIngredientByIdAsync(Guid id);
    Task AddIngredientAsync(Ingredient ingredient);
    Task UpdateIngredientAsync(Ingredient ingredient);
    Task DeleteIngredientAsync(Guid id);
}
}