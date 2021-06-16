using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class PaymentMethodModel
    {
        public int PaymentMethodId { get; set; }
        public int ClientId { get; set; }
        public string CardType { get; set; }
        public int ExpirationDateMonth { get; set; }
        public int ExpirationDateYear { get; set; }
        public int SecurityCode { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string City { get; set; }
        public string BillingAddress { get; set; }
        public string BillingAddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int PhoneNumber { get; set; }
    }
}
