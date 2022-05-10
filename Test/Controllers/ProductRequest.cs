using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Controllers
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        //public ProductRequest(
        //    List<ProductBase> productBases)
        //{
        //    Products = productBases;
        //}
        //public  IReadOnlyCollection<ProductBase> Products { get; set; }

    }

}
