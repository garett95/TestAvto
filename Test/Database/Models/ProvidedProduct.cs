using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{

    public class ProvidedProduct
    {
        public int Id { get; set; }
        [Display(Name = "Product")]
        public virtual int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductDto ProductDto { get; set; }

    }
}
