using NutricareApp.Entities;

namespace NutricareApp.Web.Models
{
    public class NutritionistModel
    {
        public int NutritionistId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int CnpNumber { get; set; }
    }
}
