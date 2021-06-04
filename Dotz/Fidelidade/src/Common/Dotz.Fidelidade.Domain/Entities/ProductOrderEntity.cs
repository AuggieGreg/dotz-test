using Dotz.Fidelidade.Domain.Common;
using Dotz.Fidelidade.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class ProductOrderEntity : AuditableEntity
    {
        public ProductOrderEntity()
        {

        }

        public ProductOrderEntity(ProductExchangeEntity productExchange) : this()
        {
            ProductOrderId = Guid.NewGuid();
            ProductId = productExchange.ProductId;
            UserId = productExchange.WalletTransaction.WalletId;
            ProductExchangeId = productExchange.ProductExchangeId;
            DeliveryStatusEnum = Enums.DeliveryStatus.Created;
        }

        public Guid ProductOrderId { get; set; }

        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public Guid ProductExchangeId { get; set; }

        public string DeliveryStatus { get; private set; }

        public DeliveryStatus DeliveryStatusEnum
        {
            get
            {
                return Enum.Parse<DeliveryStatus>(DeliveryStatus);
            }
            set
            {
                DeliveryStatus = value.ToString();
            }
        }

        public ProductExchangeEntity ProductExchange { get; set; }

        public UserEntity User { get; set; }

        public ProductEntity Product { get; set; }
    }
}
