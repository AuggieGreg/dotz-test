using Dotz.Fidelidade.Domain.Entities;
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
        private readonly ProductEntity product1;
        private readonly ProductEntity product2;
        private readonly ProductEntity product3;

        private readonly ProductCategoryEntity productCategory = new ProductCategoryEntity(Guid.NewGuid(), "Test Category", null);

        public WalletDomainTest()
        {
            product1 = new ProductEntity(Guid.NewGuid(), "Test 1", 10000, Guid.NewGuid(), productCategory);
            product2 = new ProductEntity(Guid.NewGuid(), "Test 2", 10000, Guid.NewGuid(), productCategory);
            product3 = new ProductEntity(Guid.NewGuid(), "Test 3", 10000, Guid.NewGuid(), productCategory);

            var user = new UserEntity("Augusto", "User", "hashtest", "augusto@augusto.mail", DateTime.Now, true);
            wallet = new(user);

            wallet.AddPartnerCredit(Guid.NewGuid(), "Compra X de teste 1", 5000);
            wallet.AddPartnerCredit(Guid.NewGuid(), "Compra X de teste 2", 5000);
            wallet.AddPartnerCredit(Guid.NewGuid(), "Compra X de teste 3", 5000);
            wallet.AddPartnerCredit(Guid.NewGuid(), "Compra X de teste 3", 5000);

            wallet.ExchangeNewProduct(product1, 1);
        }

        [TestMethod]
        public void ShouldBeValid()
        {
            Assert.IsTrue(wallet.Balance == 10000);
            Assert.IsTrue(wallet.WalletTransactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.NotSet).Count() == 0);
            Assert.IsTrue(wallet.WalletTransactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.Entry).Count() == 4);
            Assert.IsTrue(wallet.WalletTransactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.Exchange).Count() == 1);
        }


        [TestMethod]
        public void ShouldBeValid_BallanceShouldBeZero()
        {
            wallet.ExchangeNewProduct(product3, 1);

            Assert.IsTrue(wallet.Balance == 0);
            Assert.IsTrue(wallet.WalletTransactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.NotSet).Count() == 0);
            Assert.IsTrue(wallet.WalletTransactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.Entry).Count() == 4);
            Assert.IsTrue(wallet.WalletTransactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.Exchange).Count() == 2);
        }

        [TestMethod]
        public void ShouldBeValid_BallanceShouldBeNegative()
        {
            wallet.ExchangeNewProduct(product2, 1);
            wallet.ExchangeNewProduct(product3, 1);

            Assert.IsTrue(wallet.Balance == -10000);
            Assert.IsTrue(wallet.WalletTransactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.NotSet).Count() == 0);
            Assert.IsTrue(wallet.WalletTransactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.Entry).Count() == 4);
            Assert.IsTrue(wallet.WalletTransactions.Where(x => x.TransactionTypeEnum == Enums.TransactionType.Exchange).Count() == 3);
        }
    }
}
