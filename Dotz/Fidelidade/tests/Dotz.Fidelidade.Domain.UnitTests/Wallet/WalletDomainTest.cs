using Dotz.Fidelidade.Domain.Entities;
using Dotz.Fidelidade.Domain.UnitTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dotz.Fidelidade.Domain.UnitTests.Wallet
{
    [TestClass]
    public class WalletDomainTest
    {
        private readonly WalletEntity wallet;
        private readonly Guid productId1 = Guid.NewGuid();
        private readonly Guid productId2 = Guid.NewGuid();
        private readonly Guid productId3 = Guid.NewGuid();

        private readonly ProductCategoryEntity productCategory = new ProductCategoryEntity(Guid.NewGuid(), "Test Category", null);

        public WalletDomainTest()
        {
            var walletLoaderMock = new WalletLoaderServiceMock();

            walletLoaderMock.AddProduct(new ProductEntity(productId1, "Test 1", 10000, productCategory.ProductCategoryId, Guid.NewGuid(), productCategory));
            walletLoaderMock.AddProduct(new ProductEntity(productId2, "Test 2", 10000, productCategory.ProductCategoryId, Guid.NewGuid(), productCategory));
            walletLoaderMock.AddProduct(new ProductEntity(productId3, "Test 3", 10000, productCategory.ProductCategoryId, Guid.NewGuid(), productCategory));

            var transactions = new List<WalletTransactionEntity>();

            wallet = new(Guid.NewGuid(), transactions, walletLoaderMock);

            wallet.AddPartnerCredit(Guid.NewGuid(), "Compra X de teste 1", 5000);
            wallet.AddPartnerCredit(Guid.NewGuid(), "Compra X de teste 2", 5000);
            wallet.AddPartnerCredit(Guid.NewGuid(), "Compra X de teste 3", 5000);
            wallet.AddPartnerCredit(Guid.NewGuid(), "Compra X de teste 3", 5000);

            wallet.ExchangeNewProduct(productId1, 1);
        }

        [TestMethod]
        public void ShouldBeValid()
        {
            Assert.IsTrue(wallet.Balance == 10000);
            Assert.IsTrue(wallet.Transactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.NotSet).Count() == 0);
            Assert.IsTrue(wallet.Transactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.Entry).Count() == 4);
            Assert.IsTrue(wallet.Transactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.Exchange).Count() == 1);
        }


        [TestMethod]
        public void ShouldBeValid_BallanceShouldBeZero()
        {
            wallet.ExchangeNewProduct(productId3, 1);

            Assert.IsTrue(wallet.Balance == 0);
            Assert.IsTrue(wallet.Transactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.NotSet).Count() == 0);
            Assert.IsTrue(wallet.Transactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.Entry).Count() == 4);
            Assert.IsTrue(wallet.Transactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.Exchange).Count() == 2);
        }

        [TestMethod]
        public void ShouldBeValid_BallanceShouldBeNegative()
        {
            wallet.ExchangeNewProduct(productId2, 1);
            wallet.ExchangeNewProduct(productId3, 1);

            Assert.IsTrue(wallet.Balance == -10000);
            Assert.IsTrue(wallet.Transactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.NotSet).Count() == 0);
            Assert.IsTrue(wallet.Transactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.Entry).Count() == 4);
            Assert.IsTrue(wallet.Transactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.Exchange).Count() == 3);
        }
    }
}
