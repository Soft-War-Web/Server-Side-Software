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
    public class ProfessionalprofilesController : ControllerBase
    {
        private readonly DbContextNutricareApp _context;

        public ProfessionalprofilesController(DbContextNutricareApp context)
        {
            _context = context;
        }

        // GET: api/Professionalprofiles
        [HttpGet]
        public async Task<IEnumerable<ProfessionalprofileModel>> GetProfessionalprofiles()
        {
            var professionalprofileList = await _context.Professionalprofiles.ToListAsync();

            return professionalprofileList.Select(c => new ProfessionalprofileModel
            {
                ProfessionalprofileId = c.ProfessionalprofileId,
                NutritionistId = c.NutritionistId,
                ProfessionalExperienceDescription = c.ProfessionalExperienceDescription
            });
        }

        // GET: api/Professionalprofiles/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProfessionalprofileById([FromRoute] int id)
        {
            var profesionalprofile = await _context.Professionalprofiles.FindAsync(id);

            if (profesionalprofile == null)
            {
                return NotFound();
            }

            return Ok(new ProfessionalprofileModel
            {
                ProfessionalprofileId = profesionalprofile.ProfessionalprofileId,
                NutritionistId = profesionalprofile.NutritionistId,
                ProfessionalExperienceDescription = profesionalprofile.ProfessionalExperienceDescription
            });
        }

        // PUT: api/Professionalprofiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutProfessionalprofile([FromBody] UpdateProfessionalprofileModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (model.ProfessionalprofileId <= 0)
                return BadRequest();

            var professionalprofile = await _context.Professionalprofiles.FirstOrDefaultAsync(c => c.ProfessionalprofileId == model.ProfessionalprofileId);

            if (professionalprofile == null)
                return NotFound();

            //La Id debe ser la misma
            professionalprofile.ProfessionalprofileId = model.ProfessionalprofileId; //podría agregarse nut id
            professionalprofile.ProfessionalExperienceDescription = model.ProfessionalExperienceDescription;

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

        // POST: api/Professionalprofiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProfessionalprofile([FromBody] CreateProfessionalprofileModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Professionalprofile professionalprofile = new Professionalprofile //Esto es lo que se guarda en BD
            {
                NutritionistId = model.NutritionistId,
                ProfessionalExperienceDescription = model.ProfessionalExperienceDescription
            };

            _context.Professionalprofiles.Add(professionalprofile);

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

        // DELETE: api/Professionalprofiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessionalprofile([FromRoute] int id)
        {
            var professionalprofile = await _context.Professionalprofiles.FindAsync(id);
            if (professionalprofile == null)
            {
                return NotFound();
            }

            _context.Professionalprofiles.Remove(professionalprofile);

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

        private bool ProfessionalprofileExists(int id)
        {
            return _context.Professionalprofiles.Any(e => e.ProfessionalprofileId == id);
        }
    }
}
