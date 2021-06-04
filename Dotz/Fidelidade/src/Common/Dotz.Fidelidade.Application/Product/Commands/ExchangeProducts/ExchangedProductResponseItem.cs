using Dotz.Fidelidade.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Product.Commands.ExchangeProducts
{
    public class ExchangedProductResponseItem
    {
        public ProductDto Product { get; set; }

        public bool SuccessExchange { get { return !string.IsNullOrEmpty(FailedMessage); } }

        public string FailedMessage { get; set; }
    }
}
