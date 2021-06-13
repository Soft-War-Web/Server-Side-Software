using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutricareApp.Entities
{
    public class DietRecipe
    {
        [Required(ErrorMessage = "Debe incluir un DietId")]
        public int DietId { get; set; }
        [Required(ErrorMessage = "Debe incluir un RecipeId")]
        public int RecipeId { get; set; }

        public virtual Diet Diet { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
