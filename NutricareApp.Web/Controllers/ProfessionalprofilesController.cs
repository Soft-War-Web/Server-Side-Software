using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutricareApp.Data;
using NutricareApp.Entities;

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
        public async Task<ActionResult<IEnumerable<Professionalprofile>>> GetProfessionalprofiles()
        {
            return await _context.Professionalprofiles.ToListAsync();
        }

        // GET: api/Professionalprofiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Professionalprofile>> GetProfessionalprofile(int id)
        {
            var professionalprofile = await _context.Professionalprofiles.FindAsync(id);

            if (professionalprofile == null)
            {
                return NotFound();
            }

            return professionalprofile;
        }

        // PUT: api/Professionalprofiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessionalprofile(int id, Professionalprofile professionalprofile)
        {
            if (id != professionalprofile.ProfessionaprofileId)
            {
                return BadRequest();
            }

            _context.Entry(professionalprofile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessionalprofileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Professionalprofiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Professionalprofile>> PostProfessionalprofile(Professionalprofile professionalprofile)
        {
            _context.Professionalprofiles.Add(professionalprofile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfessionalprofile", new { id = professionalprofile.ProfessionaprofileId }, professionalprofile);
        }

        // DELETE: api/Professionalprofiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessionalprofile(int id)
        {
            var professionalprofile = await _context.Professionalprofiles.FindAsync(id);
            if (professionalprofile == null)
            {
                return NotFound();
            }

            _context.Professionalprofiles.Remove(professionalprofile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessionalprofileExists(int id)
        {
            return _context.Professionalprofiles.Any(e => e.ProfessionaprofileId == id);
        }
    }
}
