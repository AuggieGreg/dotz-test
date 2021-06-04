using Dotz.Fidelidade.Application.Product.Queries.GetAllProductsWithPagination;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.UnitTests.Product.Queries
{
    [TestClass]
    public class GetAllProductsWithPaginationQueryValidatorTest
    {
        private readonly GetAllProductsWithPaginationQueryValidator _validator;

        private readonly GetAllProductsWithPaginationQuery _getAllProductsWithPaginationQuery;
        public GetAllProductsWithPaginationQueryValidatorTest()
        {
            _validator = new GetAllProductsWithPaginationQueryValidator();

            _getAllProductsWithPaginationQuery = new GetAllProductsWithPaginationQuery()
            {
                CategoryId = Guid.NewGuid(),
                PageNumber = 1,
                PageSize = 10,
            };

        }

        [TestMethod]
        public async Task ShouldBeValid()
        {
            var result = await _validator.ValidateAsync(_getAllProductsWithPaginationQuery);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        [DataRow(0, GetAllProductsWithPaginationQueryValidatorErrorMessages.GreaterThanOrEqualToPageNumber)]
        [DataRow(-1, GetAllProductsWithPaginationQueryValidatorErrorMessages.GreaterThanOrEqualToPageNumber)]
        [DataRow(-10, GetAllProductsWithPaginationQueryValidatorErrorMessages.GreaterThanOrEqualToPageNumber)]
        public async Task ShouldBeInalid_PageNumber(int pageNumber, string message)
        {
            _getAllProductsWithPaginationQuery.PageNumber = pageNumber;

            var result = await _validator.ValidateAsync(_getAllProductsWithPaginationQuery);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.Errors.SingleOrDefault(x => x.ErrorMessage == message));
        }

        [TestMethod]
        [DataRow(0, GetAllProductsWithPaginationQueryValidatorErrorMessages.GreaterThanOrEqualToPageSize)]
        [DataRow(-1, GetAllProductsWithPaginationQueryValidatorErrorMessages.GreaterThanOrEqualToPageSize)]
        [DataRow(-10, GetAllProductsWithPaginationQueryValidatorErrorMessages.GreaterThanOrEqualToPageSize)]
        public async Task ShouldBeInalid_PageSize(int pageSize, string message)
        {
            _getAllProductsWithPaginationQuery.PageSize = pageSize;

            var result = await _validator.ValidateAsync(_getAllProductsWithPaginationQuery);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.Errors.SingleOrDefault(x => x.ErrorMessage == message));
        }


        [TestMethod]
        public async Task ShouldBeInalid_CategoryId()
        {
            _getAllProductsWithPaginationQuery.CategoryId = Guid.Empty;

            var result = await _validator.ValidateAsync(_getAllProductsWithPaginationQuery);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.Errors.SingleOrDefault(x => x.ErrorMessage == GetAllProductsWithPaginationQueryValidatorErrorMessages.NotBeEmptyIfSetCategoryId));
        }
    }
}
