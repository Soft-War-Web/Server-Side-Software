using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutricareApp.Entities
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Debe asignar una categoria al producto")]
        public int NutritionistId { get; set; }

        [Required(ErrorMessage = "Debe incluir el nombre de la receta")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de la receta debe tener de 3 a 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe incluir la descripcion de la receta")]
        [StringLength(250, MinimumLength = 50, ErrorMessage = "la descripcion de la receta debe tener de 50 a 250 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe incluir la preparacion de la receta")]
        [StringLength(500, MinimumLength = 50, ErrorMessage = "la preparacion de la receta debe tener de 50 a 500 caracteres")]
        public string Preparation { get; set; }

        [Required(ErrorMessage = "Debe incluir los ingredientes de la receta")]
        [StringLength(500, MinimumLength = 50, ErrorMessage = "los ingredientes de la receta debe tener de 50 a 500 caracteres")]
        public string Ingredients { get; set; }

        public int Favotite { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de creacion de la receta")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de modificación del cliente")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime LastModification { get; set; }

        public virtual Nutritionist Nutritionist { get; set; }
    }
}