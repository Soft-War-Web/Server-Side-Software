using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutricareApp.Web.Models
{
    public class BillModel
    {
        public int BillId { get; set; }
        public int ClientId { get; set; }
        public decimal Amount { get; set; }
        public int Ruc { get; set; }
        public DateTime BillDate { get; set; }
    }
}
