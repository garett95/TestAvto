using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Controllers
{
    public class SalePointRequest
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
