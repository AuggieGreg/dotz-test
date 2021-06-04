using Dotz.Fidelidade.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Domain.Entities
{
    public class ProductCategoryEntity : AuditableEntity
    {
        public ProductCategoryEntity()
        {
            ChildCategories = new List<ProductCategoryEntity>();
        }

        public ProductCategoryEntity(Guid productCategoryId, string name, Guid? parentCategoryId) : this()
        {
            ProductCategoryId = productCategoryId;
            Name = name;
            ParentCategoryId = parentCategoryId;
        }

        public Guid ProductCategoryId { get; set; }

        public string Name { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public ProductCategoryEntity ParentCategory { get; set; }

        public IList<ProductCategoryEntity> ChildCategories { get; set; }
    }
}
