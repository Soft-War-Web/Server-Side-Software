using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class CreateRecipeModel
    {
        [Required(ErrorMessage = "Debe asignar un nutricionista a la receta")]
        public int NutritionistId { get; set; }

        [Required(ErrorMessage = "Debe incluir el nombre de la receta")]
        [StringLength(50, ErrorMessage = "El nombre de la receta debe tener hasta 50 caracteres")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "la descripcion de la receta debe tener hasta 250 caracteres")]
        public string Description { get; set; }

        public int Favorites { get; set; }

        [StringLength(500, ErrorMessage = "la preparacion de la receta debe tener hasta 500 caracteres")]
        public string Preparation { get; set; }

        [StringLength(500, ErrorMessage = "los ingredientes de la receta debe tener hasta 500 caracteres")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de creacion de la receta")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de modificación del cliente")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime LastModification { get; set; }
    }
}
