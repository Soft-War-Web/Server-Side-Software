using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class RecipeModel
    {
        public int NutritionistId { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int Favorites { get; set; }
        public string Description { get; set; }
        public string Preparation { get; set; }
        public string Ingredients { get; set; }
    }
}