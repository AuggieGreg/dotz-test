using Dotz.Fidelidade.Domain.Common;
using System;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class ProductEntity : AuditableEntity
    {
        public ProductEntity()
        {

        }

        public ProductEntity(Guid productId, string name, decimal price, Guid categoryId, Guid partnerId, ProductCategoryEntity category)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            PartnerId = partnerId;
            CategoryId = categoryId;
            Category = category;
        }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid PartnerId { get; set; }

        public Guid CategoryId { get; set; }

        public ProductCategoryEntity Category { get; set; }
    }
}
