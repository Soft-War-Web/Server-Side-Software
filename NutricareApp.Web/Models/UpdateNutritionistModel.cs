using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class UpdateNutritionistModel
    {
        public int NutritionistId { get; set; }

        //public int ProfessionalProfileId { get; set; }
        [Required(ErrorMessage = "Debe incluir el username del cliente")]
        [StringLength(16, ErrorMessage = "El username del cliente debe tener hasta 16 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe incluir la contraseña del cliente")]
        [StringLength(60, ErrorMessage = "La contraseña del cliente debe tener hasta 60 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Debe incluir el nombre del cliente")]
        [StringLength(50, ErrorMessage = "El nombre del cliente no debe tener más 50 caracteres")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Debe incluir el apellido del cliente")]
        [StringLength(50, ErrorMessage = "El apellido del cliente no debe tener más 50 caracteres")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Debe incluir el email del cliente")]
        [StringLength(50, ErrorMessage = "El email del cliente debe tener un máximo de 50 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Debe incluir el número del Colegio de Nutricionistas del Perú (CNP) del nutricionista")]
        public int CnpNumber { get; set; }
    }
}
