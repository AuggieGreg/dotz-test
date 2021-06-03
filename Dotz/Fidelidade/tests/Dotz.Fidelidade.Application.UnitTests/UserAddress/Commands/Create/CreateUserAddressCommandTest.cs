using Dotz.Fidelidade.Application.UserAddress.Commands.Create;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.UnitTests.UserAddress.Commands.Create
{
    [TestClass]
    public class CreateUserAddressCommandTest
    {
        private readonly CreateUserAddressCommandValidator _validator;

        private readonly CreateUserAddressCommand _createUserAddressCommand;

        public CreateUserAddressCommandTest()
        {
            _validator = new();

            _createUserAddressCommand = new() { 
                Address = "Valid address",
                Number = null, 
                Complement = string.Empty,
                PostalCode = "12900-999"
            };
        }

        [TestMethod]
        public async Task ShouldBeValid()
        {
            var result = await _validator.ValidateAsync(_createUserAddressCommand);

            Assert.IsTrue(result.IsValid);
        }


        [TestMethod]
        [DataRow(null, CreateUserAddressCommandErrorMessages.EmptyAddress)]
        [DataRow(0, CreateUserAddressCommandErrorMessages.EmptyAddress)]
        [DataRow(501, CreateUserAddressCommandErrorMessages.MaximumLengthAddress)]
        public async Task ShouldBeInvalid_Address(int? repeatAmount, string message)
        {
            _createUserAddressCommand.Address = repeatAmount.HasValue ? new string('p', repeatAmount.Value) : null;
            var result = await _validator.ValidateAsync(_createUserAddressCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.Errors.SingleOrDefault(s => s.ErrorMessage == message));
        }

        [TestMethod]
        [DataRow(201, CreateUserAddressCommandErrorMessages.MaximumLengthComplement)]
        public async Task ShouldBeInvalid_Complement(int? repeatAmount, string message)
        {
            _createUserAddressCommand.Complement = repeatAmount.HasValue ? new string('p', repeatAmount.Value) : null;
            var result = await _validator.ValidateAsync(_createUserAddressCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.Errors.SingleOrDefault(s => s.ErrorMessage == message));
        }
    }
}
