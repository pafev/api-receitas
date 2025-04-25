using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApiReceitas.Domain.Models
{
    [PrimaryKey(nameof(RecipeId), nameof(IngredientId))]
    [Table("RecipeIngredients")]
    public class RecipeIngredient
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Recipes")]
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Ingredients")]
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        [Required]
        public decimal IngredientQuantity { get; set; }
    }
}