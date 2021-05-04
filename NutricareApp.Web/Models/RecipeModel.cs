using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class RecipeModel
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public string Preparation { get; set; }
        public string Ingredients { get; set; }
    }
}