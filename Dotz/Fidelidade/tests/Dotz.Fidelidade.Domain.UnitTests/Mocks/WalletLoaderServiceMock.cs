using Dotz.Fidelidade.Domain.Entities;
using Dotz.Fidelidade.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Domain.UnitTests.Mocks
{
    class WalletLoaderServiceMock : IWalletLoaderService
    {
        private readonly IList<ProductEntity> _productEntities;
        public WalletLoaderServiceMock()
        {
            _productEntities = new List<ProductEntity>();
        }

        public void AddProduct(ProductEntity product)
        {
            _productEntities.Add(product);
        }

        public ProductEntity LoadProduct(Guid productId)
        {
            return _productEntities.First(x => x.ProductId == productId);
        }
    }
}
