using Microsoft.EntityFrameworkCore;
using ApiReceitas.Domain.Models;

namespace ApiReceitas.Persistence
{
    public class SqLiteDbContext: DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasMany(e => e.Ingredients)
                .WithMany(e => e.Recipes)
                .UsingEntity<RecipeIngredient>();
        }
        #endregion

        public SqLiteDbContext(DbContextOptions<SqLiteDbContext> options): base(options)
        {
        }
    }
}