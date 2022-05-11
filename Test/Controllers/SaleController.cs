using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Application;
using Test.Database;
using Test.Models;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly IApplicationCreator _applicationCreator;

        private readonly ILogger<SaleController> _logger;


        public SaleController(
            ILogger<SaleController> logger,
            IApplicationCreator applicationCreator)
        {
            _applicationCreator = applicationCreator;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<BuyerDto> Get()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var buyers = db.Buyers.ToList();
                return buyers;
            }
        }

        [HttpPost]
        [Route("/buyer")]
        public async Task<IActionResult> Put(
            string name)
        {
            await _applicationCreator.CreateBuyer(name);

            return Ok();
        }


        [HttpPost]
        [Route("/sale")]
        public IActionResult Sale(
            [FromBody] SaleRequest request)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var sale = new SaleDto
                {
                    Date = request.Date,
                    SalesPointId = request.SalesPointId,
                    BuyerId = request.BuyerId,
                    SalesData = new List<SaleDataDto>()
                    {
                        new SaleDataDto
                        {
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
            var product = new ProductDto
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
            providedProducts.Add(new ProvidedProduct
            {
                ProductId = request.ProductId,
                ProductQuantity = request.ProductQuantity
            });

            var salePoint = new SalesPointDto
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