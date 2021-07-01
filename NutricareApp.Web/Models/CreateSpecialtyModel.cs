using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class CreateSpecialtyModel
    {

        [Required(ErrorMessage = "Debe incluir un nombre")]
        [StringLength(50, ErrorMessage = "El nombre debe tener hasta 50 caracteres")]
        public string SpecialtyName { get; set; }

        [Required(ErrorMessage = "Debe incluir una institucion")]
        [StringLength(50, ErrorMessage = "La descripcion debe tener hasta 50 caracteres")]
        public string InstitutionName { get; set; }
    }
}
