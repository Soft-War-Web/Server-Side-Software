using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutricareApp.Entities
{
    public class ClientRecipe
    {
        [Required(ErrorMessage = "Debe incluir un ClientId")]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Debe incluir un RecipeId")]
        public int RecipeId { get; set; }
        public Client Client { get; set; }
        public Recipe Recipe { get; set; }
    }
}
