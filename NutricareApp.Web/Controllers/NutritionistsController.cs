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
    [Route("api/[controller]")] //localhost:8080/api/nutritionists
    [ApiController]
    public class NutritionistsController : ControllerBase
    {
        private readonly DbContextNutricareApp _context;

        public NutritionistsController(DbContextNutricareApp context)
        {
            _context = context;
        }

        // GET: api/Nutritionists
        [HttpGet]
        public async Task<IEnumerable<NutritionistModel>> GetNutritionists()
        {
            var nutritionistList = await _context.Nutritionists.ToListAsync();

            return nutritionistList.Select(c => new NutritionistModel
            {
                NutritionistId = c.NutritionistId,
                //ProfessionalProfileId = c.ProfessionalProfileId,
                Username = c.Username,
                FirstName = c.FirstName,
                LastName = c.LastName,
                CnpNumber = c.CnpNumber,
                Email = c.Email
            });
        }


        // GET: api/Nutritionists/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetNutritionistById([FromRoute] int id)
        {
            var nutritionist = await _context.Nutritionists.FindAsync(id);

            if (nutritionist == null)
            {
                return NotFound();
            }

            return Ok(new NutritionistModel
            {
                NutritionistId = nutritionist.NutritionistId,
                //ProfessionalProfileId = nutritionist.ProfessionalProfileId,
                Username = nutritionist.Username,
                FirstName = nutritionist.FirstName,
                LastName = nutritionist.LastName,
                CnpNumber = nutritionist.CnpNumber,
                Email = nutritionist.Email
            });
        }

        [HttpGet("[action]/{NutritionistId}")]
        public async Task<IEnumerable<SpecialtyModel>> GetSpecialtiesFromNutritionist([FromRoute] int NutritionistId)
        {
            var professionalprofile = await _context.Professionalprofiles
                                    .Include(d => d.Specialties)
                                    .FirstOrDefaultAsync(d => d.NutritionistId == NutritionistId);
            var specialties = professionalprofile.Specialties.ToList();
            return specialties.Select(c => new SpecialtyModel
            {
                SpecialtyId = c.SpecialtyId,
                SpecialtyName = c.SpecialtyName,
                InstitutionName = c.InstitutionName
            });
        }


        // PUT: api/Nutritionists/PutNutritionist
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutNutritionist([FromBody] UpdateNutritionistModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (model.NutritionistId <= 0)
                return BadRequest();

            var nutritionist = await _context.Nutritionists.FirstOrDefaultAsync(c => c.NutritionistId == model.NutritionistId);

            if (nutritionist == null)
                return NotFound();

            //La Id debe ser la misma
            //nutritionist.ProfessionalProfileId = model.ProfessionalProfileId;
            nutritionist.Username = model.Username;
            nutritionist.Password = model.Password;
            nutritionist.FirstName = model.FirstName; //Se debe encriptar para que se guarde así en la BD (FALTA)
            nutritionist.LastName = model.LastName;
            nutritionist.Email = model.Email;
            nutritionist.CnpNumber = model.CnpNumber;

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

        // POST: api/Nutritionists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostNutritionist([FromBody] CreateNutritionistModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Nutritionist nutritionist = new Nutritionist //Esto es lo que se guarda en BD
            {
                //ProfessionalProfileId = model.ProfessionalProfileId,
                Username = model.Username,
                Password = model.Password, //Se debe encriptar para que se guarde así en la BD (FALTA)
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                CnpNumber = model.CnpNumber,
                CreatedAt = model.CreatedAt
            };

            _context.Nutritionists.Add(nutritionist);

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


        // DELETE: api/Nutritionists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNutritionist([FromRoute] int id)
        {
            var nutritionist = await _context.Nutritionists.FindAsync(id);
            if (nutritionist == null)
            {
                return NotFound();
            }

            _context.Nutritionists.Remove(nutritionist);

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

        //Añadir más métodos

        ////put: api/categories/updatecondition/{id}/{condition}
        //[httpput("[action]/{id}/{condition}")]
        //public async task<iactionresult> updatecondition([fromroute] int id, [fromroute] bool condition)
        //{
        //    if (id <= 0)
        //        return badrequest();

        //    var category = await _context.categories.firstordefaultasync(c => c.categoryid == id);

        //    if (category == null)
        //        return notfound();

        //    category.condition = condition;

        //    try
        //    {
        //        await _context.savechangesasync();
        //    }
        //    catch (exception ex)
        //    {
        //        return badrequest(ex.message);
        //    }

        //    return ok();
        //}
    }
}
