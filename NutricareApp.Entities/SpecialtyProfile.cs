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
        public int SpecialtyId { get; set; }
        public int ProfessionalProfileId { get; set; }

        public virtual Professionalprofile Professionalprofile { get; set; }

        public virtual Specialty Specialty { get; set; }
    }
}
