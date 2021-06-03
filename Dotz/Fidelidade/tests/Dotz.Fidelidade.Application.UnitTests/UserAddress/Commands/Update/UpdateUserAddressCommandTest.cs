using Dotz.Fidelidade.Application.UserAddress.Commands.Update;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.UnitTests.UserAddress.Commands.Update
{
    [TestClass]
    public class UpdateUserAddressCommandTest
    {
        private readonly UpdateUserAddressCommandValidator _validator;

        private readonly UpdateUserAddressCommand _updateUserAddressCommand;

        public UpdateUserAddressCommandTest()
        {
            _validator = new();

            _updateUserAddressCommand = new()
            {
                AddressId = Guid.NewGuid(),
                Address = "Valid address",
                Number = null,
                Complement = string.Empty,
                PostalCode = "12900-999"
            };
        }

        [TestMethod]
        public async Task ShouldBeValid()
        {
            var result = await _validator.ValidateAsync(_updateUserAddressCommand);

            Assert.IsTrue(result.IsValid);
        }


        [TestMethod]
        [DataRow(null, UpdateUserAddressCommandErrorMessages.EmptyAddress)]
        [DataRow(0, UpdateUserAddressCommandErrorMessages.EmptyAddress)]
        [DataRow(501, UpdateUserAddressCommandErrorMessages.MaximumLengthAddress)]
        public async Task ShouldBeInvalid_Address(int? repeatAmount, string message)
        {
            _updateUserAddressCommand.Address = repeatAmount.HasValue ? new string('p', repeatAmount.Value) : null;
            var result = await _validator.ValidateAsync(_updateUserAddressCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.Errors.SingleOrDefault(s => s.ErrorMessage == message));
        }

        [TestMethod]
        [DataRow(201, UpdateUserAddressCommandErrorMessages.MaximumLengthComplement)]
        public async Task ShouldBeInvalid_Complement(int? repeatAmount, string message)
        {
            _updateUserAddressCommand.Complement = repeatAmount.HasValue ? new string('p', repeatAmount.Value) : null;
            var result = await _validator.ValidateAsync(_updateUserAddressCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.Errors.SingleOrDefault(s => s.ErrorMessage == message));
        }

        [TestMethod]
        public async Task ShouldBeInvalid_AddressId()
        {
            _updateUserAddressCommand.AddressId = Guid.Empty;
            var result = await _validator.ValidateAsync(_updateUserAddressCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsNotNull(result.Errors.SingleOrDefault(s => s.ErrorMessage == UpdateUserAddressCommandErrorMessages.EmptyAddressId));
        }
    }
}
