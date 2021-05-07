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
    public class AppointmentsController : ControllerBase
    {
        private readonly DbContextNutricareApp _context;

        public AppointmentsController(DbContextNutricareApp context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<IEnumerable<AppointmentModel>> GetAppointments()
        {
            var appointmentList = await _context.Appointments.ToListAsync();

            return appointmentList.Select(c => new AppointmentModel
            {
                AppointmentId = c.AppointmentId,
                ClientId = c.ClientId,
                NutritionistId = c.NutritionistId,
                DietId = c.DietId,
                AppointmentDate = c.AppointmentDate,
                NutritionistNotes = c.NutritionistNotes
            });
        }

        // GET: api/Appointments/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAppointmentById([FromRoute] int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(new AppointmentModel
            {
                AppointmentId = appointment.AppointmentId,
                ClientId = appointment.ClientId,
                NutritionistId = appointment.NutritionistId,
                DietId = appointment.DietId,
                AppointmentDate = appointment.AppointmentDate,
                NutritionistNotes = appointment.NutritionistNotes
            });
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("[action]")]
        public async Task<IActionResult> PutAppointment([FromBody] UpdateAppointmentModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (model.NutritionistId <= 0)
                return BadRequest();

            var appointment = await _context.Appointments.FirstOrDefaultAsync(c => c.AppointmentId == model.AppointmentId);

            if (appointment == null)
                return NotFound();

            //La Id debe ser la misma
            appointment.AppointmentId = model.AppointmentId;
            appointment.ClientId= model.ClientId;
            appointment.NutritionistId = model.NutritionistId;
            appointment.DietId = model.DietId;
            appointment.AppointmentDate = model.AppointmentDate;
            appointment.NutritionistNotes = model.NutritionistNotes;

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

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostAppointment([FromBody] CreateAppointmentModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Appointment appointment = new Appointment //Esto es lo que se guarda en BD
            {
                ClientId = model.ClientId,
                NutritionistId = model.NutritionistId,
                DietId = model.DietId,
                AppointmentDate = model.AppointmentDate,
                NutritionistNotes = model.NutritionistNotes

            };

            _context.Appointments.Add(appointment);

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

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment([FromRoute] int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);

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
