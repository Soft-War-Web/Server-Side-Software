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
    public class RecommendationsController : ControllerBase
    {
        private readonly DbContextNutricareApp _context;

        public RecommendationsController(DbContextNutricareApp context)
        {
            _context = context;
        }

        // GET: api/Recommendations
        [HttpGet]
        public async Task<IEnumerable<RecommendationModel>> GetRecommendations()
        {
            var RecommendationList = await _context.Recommendations.ToListAsync();
            return RecommendationList.Select(c => new RecommendationModel
            {
                NutritionistId = c.NutritionistId,
                RecommendationId = c.RecommendationId,
                Name = c.Name,
                Description = c.Description,
            });
        }

        [HttpGet("[action]/{NutritionistId}")]
        public async Task<IEnumerable<RecommendationModel>> GetRecommendationsFromNutritionist([FromRoute] int NutritionistId)
        {
            var recommendationList = await _context.Recommendations.ToListAsync();
            var recommendationNutritionistList = recommendationList.Where(r => r.NutritionistId == NutritionistId);
            return recommendationNutritionistList.Select(c => new RecommendationModel
            {
                RecommendationId = c.RecommendationId,
                Name = c.Name,
                Description = c.Description,
                NutritionistId = c.NutritionistId
            });
        }

        // GET: api/Recommendations/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetRecommendationById(int id)
        {
            var recommendation = await _context.Recommendations.FindAsync(id);

            if (recommendation == null)
            {
                return NotFound();
            }

            return Ok(new RecommendationModel
            {
                NutritionistId = recommendation.NutritionistId,
                RecommendationId = recommendation.RecommendationId,
                Name = recommendation.Name,
                Description = recommendation.Description,
            });
        }

        // PUT: api/Recommendations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutRecommendation([FromBody] UpdateRecommendationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.RecommendationId <= 0)
                return BadRequest();

            var recommendation = await _context.Recommendations.FirstOrDefaultAsync(c => c.RecommendationId == model.RecommendationId);

            if (recommendation == null)
                return NotFound();

            recommendation.RecommendationId = model.RecommendationId;
            recommendation.Name = model.Name;
            recommendation.Description = model.Description;
            recommendation.LastModification = model.LastModification;

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
       
        // POST: api/Recommendations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostRecommendation([FromBody] CreateRecommendationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Recommendation recommendation = new Recommendation
            {
                NutritionistId = model.NutritionistId,
                Name = model.Name,
                Description = model.Description,
                CreatedAt = model.CreatedAt,
                LastModification = model.LastModification                
            };

            _context.Recommendations.Add(recommendation);
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

        // DELETE: api/Recommendations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecommendation([FromRoute] int id)
        {
            var recommendation = await _context.Recommendations.FindAsync(id);
            if (recommendation == null)
                return NotFound();

            _context.Recommendations.Remove(recommendation);
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
