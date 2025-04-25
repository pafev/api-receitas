namespace ApiReceitas.Domain.Models
{
    public class Ingredient
    {
        public Guid IngredientId { get; set; }
        public string? Nome { get; set; }
        public string? Unit { get; set; }
    }
}