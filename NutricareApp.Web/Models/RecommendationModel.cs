using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class RecommendationModel
    {
        public int NutritionistId { get; set; }
        public int RecommendationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
