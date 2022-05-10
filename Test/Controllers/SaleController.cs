using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Database;
using Test.Infrastructure.Mappings;
using Test.Models;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
  
        private readonly ILogger<SaleController> _logger;


        public SaleController(ILogger<SaleController> logger)
        {
      
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Buyer> Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var buyers = db.Buyers.ToList();
                return buyers;
            }
        }
        [HttpPost]
        [Route("/buyer")]
        public IActionResult Put()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                Buyer buyer1 = new Buyer { Name = "Tom" };
                Buyer buyer2 = new Buyer { Name = "Alice" };

                // добавляем их в бд
                db.Buyers.AddRange(buyer1, buyer2);
                db.SaveChanges();
            }
            return Ok();
        }


        [HttpPost]
        [Route("/sale")]
        public IActionResult Sale(
            //[FromQuery]int  salesPointId,
            //[FromQuery]int  buyerId,
            [FromBody] SaleRequest request)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var sale = new Sale
                {
                    Date = request.Date,
                    SalesPointId = request.SalesPointId,
                    BuyerId = request.BuyerId,
                    SalesData = new List<SaleData>()
                    {
                        new SaleData{
                            ProductId = request.ProductId,
                            ProductQuantity = request.ProductQuantity
                        }
                    },
                };

                db.Sales.AddRange(sale);
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpPost]
        [Route("/product")]
        public IActionResult PostProduct(
           [FromBody] ProductRequest request)
        {
            //var products = request.MapToModel();
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Products.AddRange(product);
                db.SaveChanges();
            }
            return Ok();
        }
        [HttpPost]
        [Route("/salePoint")]
        public IActionResult SalesPoint(
          [FromBody] SalePointRequest request)
        {
            //var products = request.MapToModel();
            var providedProducts = new List<ProvidedProduct>();
            providedProducts.Add( new ProvidedProduct {
                ProductId = request.ProductId,
                ProductQuantity = request.ProductQuantity});

            var salePoint = new SalesPoint
            {
                Name = request.Name,
                ProvidedProducts = providedProducts
            };

            using (ApplicationContext db = new ApplicationContext())
            {
                db.SalesPoints.AddRange(salePoint);
                db.SaveChanges();
            }
            return Ok();
        }
        

    }
}
