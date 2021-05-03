using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class UpdateRecipeModel
    {
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Debe incluir el nombre de la receta")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de la receta debe tener de 3 a 50 caracteres")]
        public string Name { get; set; }

        [StringLength(250, MinimumLength = 50, ErrorMessage = "la descripcion de la receta debe tener de 50 a 250 caracteres")]
        public string Descripcion { get; set; }

        [StringLength(500, MinimumLength = 50, ErrorMessage = "la preparacion de la receta debe tener de 50 a 500 caracteres")]
        public string Preparation { get; set; }

        [StringLength(500, MinimumLength = 50, ErrorMessage = "los ingredientes de la receta debe tener de 50 a 500 caracteres")]
        public string Ingredients { get; set; }
    }
}
