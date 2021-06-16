using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class UpdatePaymentMethodModel
    {
        public int PaymentMethodId { get; set; }

        [Required(ErrorMessage = "Debe incluir el id del cliente")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Debe incluir el tipo de tarjeta")]
        [StringLength(50, ErrorMessage = "El tipo de tarjeta no debe tener más de 50 caracteres")]
        public string CardType { get; set; }

        [Required(ErrorMessage = "Debe incluir el mes de la fecha de expiracion")]
        public int ExpirationDateMonth { get; set; }

        [Required(ErrorMessage = "Debe incluir el año de la fecha de expiracion")]
        public int ExpirationDateYear { get; set; }

        [Required(ErrorMessage = "Debe incluir el codigo de seguridad")]
        public int SecurityCode { get; set; }

        [Required(ErrorMessage = "Debe incluir el nombre del dueño de la tarjeta")]
        [StringLength(100, ErrorMessage = "El nombre del dueño no debe tener más de 100 caracteres")]
        public string OwnerFirstName { get; set; }

        [Required(ErrorMessage = "Debe incluir el apellido del dueño de la tarjeta")]
        [StringLength(100, ErrorMessage = "El apellido del dueño no debe tener más de 100 caracteres")]
        public string OwnerLastName { get; set; }

        [Required(ErrorMessage = "Debe incluir la ciudad")]
        [StringLength(50, ErrorMessage = "El nombre de la ciudad no debe tener más de 50 caracteres")]
        public string City { get; set; }

        [Required(ErrorMessage = "Debe incluir la billing address")]
        [StringLength(200, ErrorMessage = "El billing address no debe tener más de 200 caracteres")]
        public string BillingAddress { get; set; }

        [Required(ErrorMessage = "Debe incluir la billing address")]
        [StringLength(200, ErrorMessage = "El billing address no debe tener más de 200 caracteres")]
        public string BillingAddressLine2 { get; set; }

        [Required(ErrorMessage = "Debe incluir el código postal")]
        [StringLength(20, ErrorMessage = "El código postal no debe tener más de 20 caracteres")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Debe incluir el país")]
        [StringLength(50, ErrorMessage = "El país no debe tener más de 50 caracteres")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Debe incluir un número")]
        public int PhoneNumber { get; set; }
    }
}
