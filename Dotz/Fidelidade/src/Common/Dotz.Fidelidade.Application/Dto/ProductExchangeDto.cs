using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Dto
{
    public class ProductExchangeDto
    {
        public Guid ProductExchangeId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public ProductDto Product { get; set; }
    }
}
