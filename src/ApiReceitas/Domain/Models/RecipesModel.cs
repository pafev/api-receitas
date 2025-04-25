namespace ApiReceitas.Domain.Models
{
    public class Recipe
    {
        public Guid RecipeId { get; set; }
        public string Method { get; set; }
        public Ingredient[] Ingredients { get; set; }
    }
}