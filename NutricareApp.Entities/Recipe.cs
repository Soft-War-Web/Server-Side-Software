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

        [Required(ErrorMessage = "Debe asignar un nutricionista a la receta")]
        public int NutritionistId { get; set; }

        [Required(ErrorMessage = "Debe incluir el nombre de la receta")]
        [StringLength(50, ErrorMessage = "El nombre de la receta debe hasta 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe incluir la descripcion de la receta")]
        [StringLength(250, ErrorMessage = "la descripcion de la receta no debe tener más 250 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Debe incluir la preparacion de la receta")]
        [StringLength(500, ErrorMessage = "la preparacion de la receta no debe tener más 500 caracteres")]
        public string Preparation { get; set; }

        [Required(ErrorMessage = "Debe incluir los ingredientes de la receta")]
        [StringLength(500, ErrorMessage = "los ingredientes de la receta no deben tener más 500 caracteres")]
        public string Ingredients { get; set; }

        public int Favorites { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de creacion de la receta")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de modificación del cliente")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime LastModification { get; set; }

        public virtual Nutritionist Nutritionist { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<Diet> Diets { get; set; }
    }
}