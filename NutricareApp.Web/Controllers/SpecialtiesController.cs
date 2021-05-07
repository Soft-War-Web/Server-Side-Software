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
    public class SpecialtiesController : ControllerBase
    {
        private readonly DbContextNutricareApp _context;

        public SpecialtiesController(DbContextNutricareApp context)
        {
            _context = context;
        }

        // GET: api/Specialties
        [HttpGet]
        public async Task<IEnumerable<SpecialtyModel>> GetSpecialties()
        {
            var specialtyList = await _context.Specialties.ToListAsync();

            return specialtyList.Select(c => new SpecialtyModel
            {
                SpecialtyId = c.SpecialtyId,
                SpecialtyName = c.SpecialtyName,
                InstitutionName = c.InstitutionName
            });
        }

        // GET: api/Specialties/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSpecialtyById([FromRoute] int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);

            if (specialty == null)
            {
                return NotFound();
            }

            return Ok(new SpecialtyModel
            {
                SpecialtyId = specialty.SpecialtyId,
                SpecialtyName = specialty.SpecialtyName,
                InstitutionName = specialty.InstitutionName
            });
        }

        // PUT: api/Specialties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutSpecialty([FromBody] UpdateSpecialtyModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (model.SpecialtyId <= 0)
                return BadRequest();

            var specialty = await _context.Specialties.FirstOrDefaultAsync(c => c.SpecialtyId == model.SpecialtyId);

            if (specialty == null)
                return NotFound();

            //La Id debe ser la misma
            specialty.SpecialtyId = model.SpecialtyId;
            specialty.SpecialtyName = model.SpecialtyName;
            specialty.InstitutionName = model.InstitutionName;

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

        // POST: api/Specialties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostSpecialty([FromBody] CreateSpecialtyModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Specialty specialty = new Specialty //Esto es lo que se guarda en BD
            {
                SpecialtyName = model.SpecialtyName,
                InstitutionName = model.InstitutionName
            };

            _context.Specialties.Add(specialty);

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

        // DELETE: api/Specialties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialty([FromRoute] int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }

            _context.Specialties.Remove(specialty);

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
