using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiReceitas.Domain.Models
{
    [Table("Ingredients")]
    public class Ingredient
    {
        [Key]
        public Guid IngredientId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string Unit { get; set; }
    }
}