using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class SaleDataDto
    {
        public int Id { get; set; }
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductIdAmount { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductDto ProductDto { get; set; }
    }
}
