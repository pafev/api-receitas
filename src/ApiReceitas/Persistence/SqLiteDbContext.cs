using Microsoft.EntityFrameworkCore;
using ApiReceitas.Domain.Models;

namespace ApiReceitas.Persistence
{
    public class SqLiteDbContext: DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public SqLiteDbContext(DbContextOptions<SqLiteDbContext> options): base(options)
        {
        }
    }
}