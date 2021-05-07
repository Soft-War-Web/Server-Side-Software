using NutricareApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class UpdateAppointmentModel
    {
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Debe asignar un cliente a la cita")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Debe asignar un nutricionista a la cita")]
        public int NutritionistId { get; set; }

        public int DietId { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de creación de la cita")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime AppointmentDate { get; set; }

        [StringLength(500, ErrorMessage = "Las notas del nutricionista no deben tener más 50 caracteres")]
        public string NutritionistNotes { get; set; }
    }
}