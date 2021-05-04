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
                RecommendationId = c.RecommendationId,
                Name = c.Name,
                Description = c.Description,
                CreatedAt = c.CreatedAt,
                LastModification = c.LastModification
            });
        }

        // GET: api/Recommendations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecommendationById(int id)
        {
            var recommendation = await _context.Recommendations.FindAsync(id);

            if (recommendation == null)
            {
                return NotFound();
            }

            return Ok(new RecommendationModel
            {
                RecommendationId = recommendation.RecommendationId,
                Name = recommendation.Name,
                Description = recommendation.Description,
                CreatedAt = recommendation.CreatedAt,
                LastModification = recommendation.LastModification,
            });


        }

        // PUT: api/Recommendations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecommendation([FromBody] UpdateRecommendationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.RecommendationtId <= 0)
                return BadRequest();

            var recommendation = await _context.Recommendations.FirstOrDefaultAsync(c => c.RecommendationtId == model.RecommendationtId);

            if (recommendation == null)
                return NotFound();

            recommendation.Name = model.Name;
            recommendation.Description = model.Description;


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
                Name = model.Name,
                Description = model.Description
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

        private bool RecommendationExists(int id)
        {
            return _context.Recommendations.Any(e => e.RecommendationId == id);
        }
    }
}
