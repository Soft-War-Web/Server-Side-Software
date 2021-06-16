using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NutricareApp.Data;
using NutricareApp.Entities;
using NutricareApp.Web.Models;

namespace NutricareApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietsController : ControllerBase
    {
        private readonly DbContextNutricareApp _context;

        public DietsController(DbContextNutricareApp context)
        {
            _context = context;
        }

        // GET: api/Diets
        [HttpGet]
        public async Task<IEnumerable<DietModel>> GetDiets()
        {
            var dietsList = await _context.Diets.ToListAsync();

            return dietsList.Select(c => new DietModel
            {
                DietId = c.DietId,
                DietName = c.DietName,
                DietDescription = c.DietDescription,
                CreatedAt = c.CreatedAt,
                Appointment = c.Appointment,
            });
        }

        // GET: api/Diets/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetDietById([FromRoute] int id)
        {
            var diet = await _context.Diets.FindAsync(id);

            if (diet == null)
            {
                return NotFound();
            }

            return Ok(new DietModel
            {
                DietId = diet.DietId,
                DietName = diet.DietName,
                DietDescription = diet.DietDescription,
                CreatedAt = diet.CreatedAt,
                Appointment = diet.Appointment
            });
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Diet>> GetRecipesFromDiet([FromForm] bool strip_nulls = true)
        {
            var diet = _context.Diets.AsQueryable();
            diet = diet.Include(d => d.Recipes).AsNoTracking();
            List<Diet> _return = await diet.ToListAsync();
            return _return;
        }

        // PUT: api/Diets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutDiet([FromBody] UpdateDietModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (model.DietId <= 0)
                return BadRequest();

            var diet = await _context.Diets.FirstOrDefaultAsync(c => c.DietId == model.DietId);

            if (diet == null)
                return NotFound();

            //La Id debe ser la misma
            diet.DietId = model.DietId;
            diet.DietName = model.DietName;
            diet.DietDescription = model.DietDescription;
            diet.CreatedAt = model.CreatedAt;


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

        [HttpPut("[action]/{DietId}/{RecipeId}")]
        public async Task<IActionResult> AddRecipe([FromRoute] int DietId, [FromRoute] int RecipeId)
        {
            var diet = await _context.Diets.Include(d => d.Recipes).SingleAsync(d => d.DietId == DietId);
            var recipe = await _context.Recipes.SingleAsync(r => r.RecipeId == RecipeId);
            if (diet == null || recipe == null)
            {
                return NotFound();
            }

            diet.Recipes.Add(recipe);

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

        [HttpPut("[action]/{DietId}/{RecipeId}")]
        public async Task<IActionResult> RemoveRecipe([FromRoute] int DietId, [FromRoute] int RecipeId)
        {
            var diet = await _context.Diets.Include(d => d.Recipes).SingleAsync(d => d.DietId == DietId);
            var recipe = await _context.Recipes.SingleAsync(r => r.RecipeId == RecipeId);
            if (diet == null || recipe == null)
            {
                return NotFound();
            }

            diet.Recipes.Remove(recipe);

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

        // POST: api/Diets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostDiet([FromBody] CreateDietModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Diet diet = new Diet //Esto es lo que se guarda en BD
            {
                DietName = model.DietName,
                DietDescription = model.DietDescription,
                CreatedAt = model.CreatedAt,
            };

            _context.Diets.Add(diet);

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

        // DELETE: api/Diets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiet([FromRoute] int id)
        {
            var diet = await _context.Diets.FindAsync(id);
            if (diet == null)
            {
                return NotFound();
            }

            _context.Diets.Remove(diet);

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

        private bool DietExists(int id)
        {
            return _context.Diets.Any(e => e.DietId == id);
        }
    }
}
