using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recipesapp.Data;
using recipesapp.Models;

namespace recipesapp.Controllers
{
    [ApiController]
    [Route("v1/recipes")]
    public class RecipeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllRecipes([FromServices] DataContext context)
        {
            var recipes = context.Recipes.Include(x => x.Category).ToList();
            return Ok(recipes);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetRecipe(
            [FromServices] DataContext context,
            Guid id)
        {
            var recipe = context.Recipes.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return Ok(recipe);
        }

        [HttpPost]
        public IActionResult PostRecipe(
            [FromServices] DataContext context,
            [FromBody] Recipe model
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Recipes.Add(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteRecipe(
            [FromServices] DataContext context,
            Guid id
        )
        {
            var recipe = context.Recipes.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (recipe == null)
                return BadRequest();

            context.Recipes.Remove(recipe);
            context.SaveChanges();

            return NoContent();
        }
    }
}