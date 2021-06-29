using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutricareApp.Data;
using NutricareApp.Entities;
using NutricareApp.Web.Models;

namespace NutricareApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly DbContextNutricareApp _context;

        public RecipesController(DbContextNutricareApp context)
        {
            _context = context;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<IEnumerable<RecipeModel>> GetRecipes()
        {
            var recipeList = await _context.Recipes.ToListAsync();
            return recipeList.Select(c => new RecipeModel
            {
                NutritionistId = c.NutritionistId,
                RecipeId = c.RecipeId,
                Name = c.Name,
                Description = c.Description,
                Preparation = c.Preparation,
                Ingredients = c.Ingredients,
                Favorites = c.Favorites
            });
        }

        // GET: api/Recipes/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetRecipeById([FromRoute] int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(new RecipeModel
            { 
                NutritionistId = recipe.NutritionistId,
                RecipeId = recipe.RecipeId,
                Name = recipe.Name,
                Description = recipe.Description,
                Preparation = recipe.Preparation,
                Ingredients = recipe.Ingredients,
                Favorites = recipe.Favorites
            });
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutRecipe([FromBody] UpdateRecipeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (model.RecipeId <= 0)
                return BadRequest();

            var recipe = await _context.Recipes.FirstOrDefaultAsync(c => c.RecipeId == model.RecipeId);

            if (recipe == null)
                return NotFound();

            //La Id debe ser la misma
            recipe.RecipeId = model.RecipeId;
            recipe.Name = model.Name;
            recipe.Description = model.Description;
            recipe.Preparation = model.Preparation;
            recipe.Ingredients = model.Ingredients;
            recipe.LastModification = DateTime.Now;
            recipe.Favorites = model.Favorites;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostRecipe(CreateRecipeModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Recipe recipe = new Recipe //Esto es lo que se guarda en BD
            {
                NutritionistId = model.NutritionistId,
                Name = model.Name,
                Favorites = 0,
                Description = model.Description,
                Preparation = model.Preparation,
                Ingredients = model.Ingredients,
                CreatedAt = model.CreatedAt,
                LastModification = model.LastModification
            };

            _context.Recipes.Add(recipe);

            try
            {
                await _context.SaveChangesAsync(); //Se guarda en la BD (_context)
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe([FromRoute] int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}