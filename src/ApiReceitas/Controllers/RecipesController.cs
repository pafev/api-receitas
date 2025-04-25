using Microsoft.AspNetCore.Mvc;
using ApiReceitas.Domain.Models;
using ApiReceitas.Services;

namespace ApiReceitas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService _recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            _recipesService = recipesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await _recipesService.GetAllRecipesAsync();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipeById(Guid id)
        {
            var recipe = await _recipesService.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe([FromBody] Recipe recipe)
        {
            await _recipesService.AddRecipeAsync(recipe);
            return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.RecipeId }, recipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(Guid id, [FromBody] Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return BadRequest();
            }

            await _recipesService.UpdateRecipeAsync(recipe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            await _recipesService.DeleteRecipeAsync(id);
            return NoContent();
        }
    }
}