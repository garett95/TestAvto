using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "SalesPoint")]

        public int SalesPointId { get; set; }
        [Display(Name = "Buyer")]

        public int BuyerId { get; set; }

        public List<SaleData> SalesData { get; set; }
        public decimal TotalAmount { get; set; }

        [ForeignKey("SalesPointId")]
        public SalesPoint SalesPoint { get; set; }
        [ForeignKey("BuyerId")]
        public Buyer Buyer { get; set; }

    }
}
