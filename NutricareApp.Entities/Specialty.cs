using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutricareApp.Entities
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }

        [Required(ErrorMessage = "Debe incluir un nombre")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener de entre 3 a 50 caracteres")]
        public string SpecialtyName { get; set; }

        [Required(ErrorMessage = "Debe incluir una institucion")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "La descripcion debe tener de entre 6 a 50 caracteres")]
        public string InstitutionName { get; set; }

        public virtual ICollection<SpecialtyProfile> SpecialtyProfiles { get; set; }
    }
}
