using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiReceitas.Domain.Models
{
    [Table("Recipes")]
    public class Recipe
    {
        [Key]
        public Guid RecipeId { get; set; }

        [Required]
        public string Method { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; } = new ();
    }
}