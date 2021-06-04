using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid PartnerId { get; set; }

        public Guid CategoryId { get; set; }

        public ProductCategoryDto Category { get; set; }
    }
}
