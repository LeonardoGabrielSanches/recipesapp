using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recipesapp.Data;
using recipesapp.Models;

namespace recipesapp.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCategories([FromServices] DataContext context)
        {
            var categories = context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetCategory(
            [FromServices] DataContext context,
            Guid id
        )
        {
            var category = context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult PostCategory(
            [FromServices] DataContext context,
            [FromBody] Category model
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            context.Categories.Add(model);
            context.SaveChanges();

            return Ok(model);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteCategory(
           [FromServices] DataContext context,
           Guid id
       )
        {
            var category = context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (category == null)
                return BadRequest();

            context.Categories.Remove(category);
            context.SaveChanges();

            return NoContent();
        }
    }
}