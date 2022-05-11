using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Controllers
{
    public class SaleRequest
    {
        public DateTime Date { get; set; }

        public int SalesPointId { get; set; }
        public int BuyerId { get; set; }

        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
