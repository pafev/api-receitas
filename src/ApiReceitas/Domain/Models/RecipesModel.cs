using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiReceitas.Domain.Models
{
    [Table("recipes")]
    public class Recipe
    {
        public Guid RecipeId { get; set; }

        [Required]
        public string Method { get; set; }

        public List<Ingredient> Ingredients { get; set; } = [];
        public List<RecipeIngredient> RecipeIngredients { get; set; } = [];
    }
}