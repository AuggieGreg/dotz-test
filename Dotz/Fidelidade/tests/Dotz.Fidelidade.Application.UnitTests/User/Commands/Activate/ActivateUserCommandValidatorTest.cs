using Dotz.Fidelidade.Application.User.Commands.Activate;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.UnitTests.User.Commands.Activate
{
    [TestClass]
    public class ActivateUserCommandValidatorTest
    {
        private readonly ActivateUserCommandValidator _activateUserCommandValidator;

        private readonly ActivateUserCommand _activateUserCommand;
        public ActivateUserCommandValidatorTest()
        {
            _activateUserCommandValidator = new ActivateUserCommandValidator();
            _activateUserCommand = new ActivateUserCommand()
            {
                SecretCode = Guid.NewGuid().ToString()
            };
        }

        [TestMethod]
        public async Task ShouldBeValid()
        {
            var result = await _activateUserCommandValidator.ValidateAsync(_activateUserCommand);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("testwithverylongtestthatshouldfailbecauseitisnotofsize36")]
        [DataRow("shorttexttofail")]
        public async Task ShouldNotBeEmpty(string data)
        {
            _activateUserCommand.SecretCode = data;
            var result = await _activateUserCommandValidator.ValidateAsync(_activateUserCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == ActivateUserCommandErrorMessages.ExactLengthSecretCode));
        }
    }
}
