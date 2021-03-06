using NutricareApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class CreateProfessionalprofileModel
    {
        [Required(ErrorMessage = "Debe incluir un nutricionista")]
        public int NutritionistId { get; set; }

        [Required(ErrorMessage = "Debe incluir una descripcion")]
        [StringLength(500, ErrorMessage = "La descripcion debe tener hasta 500 caracteres")]
        public string ProfessionalExperienceDescription { get; set; }
    }
}
