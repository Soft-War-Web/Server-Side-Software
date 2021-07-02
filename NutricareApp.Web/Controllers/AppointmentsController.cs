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

            if(appointment.DietId == null)
            {
                return Ok(new AppointmentModel
                {
                    AppointmentId = appointment.AppointmentId,
                    ClientId = appointment.ClientId,
                    NutritionistId = appointment.NutritionistId,
                    AppointmentDate = appointment.AppointmentDate,
                    NutritionistNotes = appointment.NutritionistNotes
                });
            }

            return Ok(new AppointmentModel
            {
                AppointmentId = appointment.AppointmentId,
                ClientId = appointment.ClientId,
                NutritionistId = appointment.NutritionistId,
                DietId = (int)appointment.DietId,
                AppointmentDate = appointment.AppointmentDate,
                NutritionistNotes = appointment.NutritionistNotes
            });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLastAppointment()
        {
            var appointment = await _context.Appointments.OrderByDescending(a => a.AppointmentId).FirstOrDefaultAsync();

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(new AppointmentModel
            {
                AppointmentId = appointment.AppointmentId,
                ClientId = appointment.ClientId,
                NutritionistId = appointment.NutritionistId,
                AppointmentDate = appointment.AppointmentDate,
                NutritionistNotes = appointment.NutritionistNotes
            });
        }

        [HttpGet("[action]/{fecha1}/{fecha2}")]
        public async Task<IEnumerable<AppointmentModel>> GetAppointmentBetweenDates([FromRoute] string fecha1, [FromRoute] string fecha2)
        {
            var appointmentList = await _context.Appointments.ToListAsync();
            List<Appointment> appointments = new List<Appointment>();

            DateTime f1 = Convert.ToDateTime(fecha1);
            DateTime f2 = Convert.ToDateTime(fecha2);

            foreach (Appointment appointment in appointmentList)
            {
                if (f1 <= appointment.AppointmentDate && appointment.AppointmentDate <= f2)
                    appointments.Add(appointment);
            }

            return appointments.Select(c => new AppointmentModel
            {
                AppointmentId = c.AppointmentId,
                ClientId = c.ClientId,
                NutritionistId = c.NutritionistId,
                AppointmentDate = c.AppointmentDate,
                NutritionistNotes = c.NutritionistNotes
            });
        }

        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<AppointmentModel>> GetAppointmentByClient([FromRoute] int id)
        {
            var appointmentList = await _context.Appointments.ToListAsync();
            List<Appointment> appointments = new List<Appointment>();

            foreach (Appointment appointment in appointmentList)
            {
                if (appointment.ClientId == id)
                    appointments.Add(appointment);
            }

            return appointments.Select(c => new AppointmentModel
            {
                AppointmentId = c.AppointmentId,
                ClientId = c.ClientId,
                NutritionistId = c.NutritionistId,
                AppointmentDate = c.AppointmentDate,
                NutritionistNotes = c.NutritionistNotes
            });
        }

        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<AppointmentModel>> GetAppointmentByNutritionist([FromRoute] int id)
        {
            var appointmentList = await _context.Appointments.ToListAsync();
            List<Appointment> appointments = new List<Appointment>();

            foreach (Appointment appointment in appointmentList)
            {
                if (appointment.NutritionistId == id)
                    appointments.Add(appointment);
            }

            return appointments.Select(c => new AppointmentModel
            {
                AppointmentId = c.AppointmentId,
                ClientId = c.ClientId,
                NutritionistId = c.NutritionistId,
                AppointmentDate = c.AppointmentDate,
                NutritionistNotes = c.NutritionistNotes
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

        [HttpPut("[action]/{AppointmentId}/{DietId}")]
        public async Task<IActionResult> AssingDiet([FromRoute] int AppointmentId, [FromRoute] int DietId)
        {
            if (AppointmentId <= 0 || DietId <= 0)
                return BadRequest();

            var appointment = await _context.Appointments.FindAsync(AppointmentId);

            if (appointment == null)
                return NotFound();

            appointment.DietId = DietId;

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

        [HttpPut("[action]/{AppointmentId}")]
        public async Task<IActionResult> ModifyNutritionistNotes([FromRoute] int AppointmentId, [FromBody] UpdateAppointmentNutritionistNotesModel model)
        {
            if (AppointmentId <= 0)
                return BadRequest();

            var appointment = await _context.Appointments.FindAsync(AppointmentId);

            if (appointment == null)
                return NotFound();

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

        [HttpPut("[action]/{AppointmentId}/{fecha}")]
        public async Task<IActionResult> ModifyAppointmentDate([FromRoute] int AppointmentId, [FromRoute] string fecha)
        {
            if (AppointmentId <= 0)
                return BadRequest();

            var appointment = await _context.Appointments.FindAsync(AppointmentId);

            if (appointment == null)
                return NotFound();

            appointment.AppointmentDate = Convert.ToDateTime(fecha);

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
