using NutricareApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class AppointmentModel
    {
        public int AppointmentId { get; set; }
        public int ClientId { get; set; }
        public int NutritionistId { get; set; }
        public int DietId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string NutritionistNotes { get; set; }
    }
}