using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class UpdateClientModel
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Debe incluir el username del cliente")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "El username del cliente debe tener de 6 a 16 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe incluir la contraseña del cliente")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "La contraseña del cliente debe tener 60 caracteres")]
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
    }
}
