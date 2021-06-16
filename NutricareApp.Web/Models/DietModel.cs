using NutricareApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class DietModel
    {
        public int DietId { get; set; }

        [Required(ErrorMessage = "Debe incluir un nombre")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener de entre 3 a 50 caracteres")]
        public string DietName { get; set; }

        [Required(ErrorMessage = "Debe incluir una descripcion")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "La descripcion debe tener de entre 10 a 500 caracteres")]
        public string DietDescription { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de creación del cliente")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }
        public virtual Appointment Appointment { get; set; }

        public virtual IEnumerable<Recipe> Recipes { get; set; }
    }
}
