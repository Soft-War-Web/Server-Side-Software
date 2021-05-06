using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutricareApp.Entities
{
    public class Professionalprofile
    {
        public int ProfessionaprofileId { get; set; }

        [Required(ErrorMessage = "Debe incluir una descripcion")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "La descripcion debe tener de entre 10 a 500 caracteres")]
        public string ProfessionalExperienceDescription { get; set; }

        public Nutritionist Nutritionist { get; set; }

        public virtual ICollection<SpecialtyProfile> SpecialtyProfiles { get; set; }
    }
}
