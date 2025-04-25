using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiReceitas.Domain.Models
{
    [Table("ingredients")]
    public class Ingredient
    {
        public Guid IngredientId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [MaxLength(15)]
        public string Unit { get; set; }

        public List<Recipe> Recipes { get; set; } = [];
        public List<RecipeIngredient> RecipeIngredients { get; set; } = [];
    }
}