using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{

    public class ProvidedProduct
    {
        public int Id { get; set; }
        [Display(Name = "Product")]
        public virtual int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

    }
}
