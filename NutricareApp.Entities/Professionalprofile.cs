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
        public int ProfessionalprofileId { get; set; }

        [Required(ErrorMessage = "Debe incluir un nutricionista")]
        public int NutritionistId { get; set; }

        [Required(ErrorMessage = "Debe incluir una descripcion")]
        [StringLength(500, ErrorMessage = "La descripcion debe tener hasta 500 caracteres")]
        public string ProfessionalExperienceDescription { get; set; }

        public Nutritionist Nutritionist { get; set; }

        public virtual ICollection<Specialty> Specialties { get; set; }
    }
}
