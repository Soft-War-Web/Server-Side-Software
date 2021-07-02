using NutricareApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class UpdateProfessionalprofileModel
    {
        public int ProfessionalprofileId { get; set; }

        [Required(ErrorMessage = "Debe incluir una descripcion")]
        [StringLength(500, ErrorMessage = "La descripcion debe tener hasta 500 caracteres")]
        public string ProfessionalExperienceDescription { get; set; }
    }
}
