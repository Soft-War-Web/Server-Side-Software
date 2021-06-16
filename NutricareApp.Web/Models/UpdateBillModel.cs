using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class UpdateBillModel
    {
        public int BillId { get; set; }

        [Required(ErrorMessage = "Debe incluir el id del cliente")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Debe incluir el monto del bill")]
        public decimal Amount { get; set; }

        public int Ruc { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de creación del cliente")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BillDate { get; set; }
    }
}
