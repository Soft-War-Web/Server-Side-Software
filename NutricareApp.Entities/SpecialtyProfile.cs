using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NutricareApp.Entities
{
    public class SpecialtyProfile
    {
        [Required(ErrorMessage = "Debe incluir un SpecialtyId")]
        public int SpecialtyId { get; set; }
        [Required(ErrorMessage = "Debe incluir un ProfessionalProfileId")]
        public int ProfessionalProfileId { get; set; }

        public virtual Professionalprofile Professionalprofile { get; set; }

        public virtual Specialty Specialty { get; set; }
    }
}
