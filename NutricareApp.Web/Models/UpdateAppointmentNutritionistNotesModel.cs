using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class UpdateAppointmentNutritionistNotesModel
    {
        [Required(ErrorMessage = "Debe agregar alguna anotación")]
        [StringLength(500, ErrorMessage = "Las notas del nutricionista no deben tener más 50 caracteres")]
        public string NutritionistNotes { get; set; }
    }
}
