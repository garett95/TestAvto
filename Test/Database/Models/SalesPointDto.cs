using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class SalesPointDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProvidedProduct> ProvidedProducts { get; set; }
    }
}
