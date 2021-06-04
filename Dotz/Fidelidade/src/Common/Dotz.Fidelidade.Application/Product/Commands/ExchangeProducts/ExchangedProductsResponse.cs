using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Product.Commands.ExchangeProducts
{
    public class ExchangedProductsResponse
    {
        public ExchangedProductsResponse()
        {
            ExchangeResults = new();
        }
        public List<ExchangedProductResponseItem> ExchangeResults { get; set; }

        public decimal CurrentBalance { get; set; }
    }
}
