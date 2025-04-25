using Microsoft.AspNetCore.Mvc;
using ApiReceitas.Domain.Models;
using ApiReceitas.Services;

namespace ApiReceitas.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientsService _ingredientsService;

    public IngredientsController(IIngredientsService ingredientsService)
    {
        _ingredientsService = ingredientsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllIngredients()
    {
        var ingredients = await _ingredientsService.GetAllIngredientsAsync();
        return Ok(ingredients);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIngredientById(Guid id)
    {
        var ingredient = await _ingredientsService.GetIngredientByIdAsync(id);
        if (ingredient == null)
        {
            return NotFound();
        }
        return Ok(ingredient);
    }

    [HttpPost]
    public async Task<IActionResult> AddIngredient([FromBody] Ingredient ingredient)
    {
        await _ingredientsService.AddIngredientAsync(ingredient);
        return CreatedAtAction(nameof(GetIngredientById), new { id = ingredient.IngredientId }, ingredient);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateIngredient(Guid id, [FromBody] Ingredient ingredient)
    {
        if (id != ingredient.IngredientId)
        {
            return BadRequest();
        }

        await _ingredientsService.UpdateIngredientAsync(ingredient);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredient(Guid id)
    {
        await _ingredientsService.DeleteIngredientAsync(id);
        return NoContent();
    }
}

}