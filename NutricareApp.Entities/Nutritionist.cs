using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutricareApp.Entities
{
    public class Nutritionist
    {
        public int NutritionistId { get; set; }

        //public int ProfessionalProfileId { get; set; }

        [Required(ErrorMessage = "Debe incluir el username del nutricionista")]
        [StringLength(16, ErrorMessage = "El username del nutricionista debe tener hasta 16 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe incluir la contraseña del nutricionista")]
        [StringLength(60, ErrorMessage = "La contraseña del nutricionista debe tener haasta 60 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe incluir el nombre del nutricionista")]
        [StringLength(50, ErrorMessage = "El nombre del nutricionista no debe tener más 50 caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Debe incluir el apellido del nutricionista")]
        [StringLength(50, ErrorMessage = "El apellido del nutricionista no debe tener más 50 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Debe incluir el email del nutricionista")]
        [StringLength(50, ErrorMessage = "El email del nutricionista debe tener un máximo de 50 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe incluir el número del Colegio de Nutricionistas del Perú (CNP) del nutricionista")]
        public int CnpNumber { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de creación del nutricionista")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }
        
        public Professionalprofile ProfessionalProfile {get; set;}

        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Recommendation> Recommendations { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
