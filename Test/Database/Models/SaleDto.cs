using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class SaleDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "SalesPoint")]

        [Required]
        public int SalesPointId { get; set; }
        [Display(Name = "Buyer")]

        public int BuyerId { get; set; }

        public List<SaleDataDto> SalesData { get; set; }
        public decimal TotalAmount { get; set; }

        [ForeignKey("SalesPointId")]
        public SalesPointDto SalesPointDto { get; set; }
        [ForeignKey("BuyerId")]
        public BuyerDto BuyerDto { get; set; }

    }
}
