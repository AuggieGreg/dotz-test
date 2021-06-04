using System;

namespace Dotz.Fidelidade.Application.Dto
{
    public class ProductOrderDto
    {
        public Guid ProductOrderId { get; set; }

        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public Guid ProductExchangeId { get; set; }

        public string DeliveryStatus { get; set; }

        public ProductDto Product { get; set; }
    }
}
