using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Product.Commands.ExchangeProducts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.UnitTests.Product.Commands.ExchangeProducts
{
    [TestClass]
    public class ExchangeProductsCommandValidatorTest
    {
        private readonly Guid _notExistentProductId = Guid.NewGuid();

        private readonly Guid _existentProductId1 = Guid.NewGuid();
        private readonly Guid _existentProductId2 = Guid.NewGuid();

        private readonly ServiceProvider _provider;

        private readonly ExchangeProductsCommand _exchangeProductsCommand;
        public ExchangeProductsCommandValidatorTest()
        {
            var mockProductQueries = new Mock<IProductQuerier>();
            mockProductQueries.Setup(s => s.ExistsById(_notExistentProductId, new())).Returns(Task.FromResult(false));
            mockProductQueries.Setup(s => s.ExistsById(_existentProductId1, new())).Returns(Task.FromResult(true));
            mockProductQueries.Setup(s => s.ExistsById(_existentProductId2, new())).Returns(Task.FromResult(true));

            var collection = new ServiceCollection();
            collection.AddSingleton<IProductQuerier>(mockProductQueries.Object);
            collection.AddScoped<ExchangeProductsCommandValidator>();

            _provider = collection.BuildServiceProvider();

            _exchangeProductsCommand = new ExchangeProductsCommand()
            {
                ProductRequests = new List<ExchangeProductCommandItem>()
                {
                    new ExchangeProductCommandItem()
                    {
                       ProductId = _existentProductId1,
                       Quantity = 1
                    },
                    new ExchangeProductCommandItem()
                    {
                       ProductId = _existentProductId2,
                       Quantity = 2
                    }
                }
            };
        }

        [TestMethod]
        public async Task ShouldBeValid() 
        {
            var validator = _provider.GetService<ExchangeProductsCommandValidator>();
            var result = await validator.ValidateAsync(_exchangeProductsCommand);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        [DataRow(0, 0,ExchangeProductCommandItemErrorMessages.GreaterThanOrEqualToQuantity)]
        [DataRow(-10, 0,ExchangeProductCommandItemErrorMessages.GreaterThanOrEqualToQuantity)]
        [DataRow(0, 1,ExchangeProductCommandItemErrorMessages.GreaterThanOrEqualToQuantity)]
        [DataRow(-200, 1, ExchangeProductCommandItemErrorMessages.GreaterThanOrEqualToQuantity)]
        public async Task ShouldBeInvalid_Quantity(int quantity, int position, string message)
        {
            message = string.Format(message);
            var validator = _provider.GetService<ExchangeProductsCommandValidator>();

            _exchangeProductsCommand.ProductRequests[position].Quantity = quantity;

            var result = await validator.ValidateAsync(_exchangeProductsCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.Errors.SingleOrDefault(x => x.ErrorMessage == message));
        }
    }
}
