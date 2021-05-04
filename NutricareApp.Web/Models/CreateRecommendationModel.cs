using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class CreateRecommendationModel
    {
        [Required(ErrorMessage = "Debe incluir el name de la recommendacion")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "El name de la recommendacion debe tener de 5 a 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe incluir la descripcion de la recommendacion")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "La descripcion de la recommendacion debe tener menos de 250 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de creación de la recommendacion")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de modificacion de la  recommendacion")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime LastModification { get; set; }
    }
}
