using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutricareApp.Entities
{
    public class Recommendation
    {
        public int RecommendationId { get; set; }

        [Required(ErrorMessage = "Debe asignar un nutricionista a la recomendación")]
        public int NutritionistId { get; set; }

        [Required(ErrorMessage = "Debe incluir el name del recommendation")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "El name del recommendation debe tener de 5 a 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe incluir la descripcion del recommendation")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "La descripcion del recommendation debe tener menos de 250 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de creación del recommendation")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string CreatedAt { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de la modificacion del recommendation")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string LastNotification { get; set; }

        public virtual Nutritionist Nutritionist { get; set; }

    }
}