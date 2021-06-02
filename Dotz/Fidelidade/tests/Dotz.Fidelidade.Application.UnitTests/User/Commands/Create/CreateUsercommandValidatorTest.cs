using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.User.Commands.Create;
using Dotz.Fidelidade.Domain.Entities;
using Dotz.Fidelidade.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.UnitTests.User.Commands.Create
{
    [TestClass]
    public class CreateUsercommandValidatorTest
    {
        private readonly ServiceProvider _provider;

        private readonly CreateUserCommand _createUserCommand;

        public CreateUsercommandValidatorTest()
        {
            var mockDate = new Mock<IDateTime>();
            mockDate.Setup(s => s.Now).Returns(new DateTime(2021, 05, 25));

            var mockUserQueries = new Mock<IUserEntityQuerier>();
            mockUserQueries.Setup(s => s.HasUniqueEmail("mail@valid.com", new System.Threading.CancellationToken())).Returns(Task.FromResult(true));
            mockUserQueries.Setup(s => s.HasUniqueEmail("mail@invalid.com", new System.Threading.CancellationToken())).Returns(Task.FromResult(false));

            var collection = new ServiceCollection();
            collection.AddSingleton<IDateTime>(mockDate.Object);
            collection.AddSingleton<IUserEntityQuerier>(mockUserQueries.Object);
            collection.AddScoped<CreateUserCommandValidator>();

            _provider = collection.BuildServiceProvider();

            _createUserCommand = new CreateUserCommand()
            {
                BirthDate = new DateTime(2000, 05, 25),
                Password = "validpw",
                ConfirmPassword = "validpw",
                Email = "mail@valid.com",
                Name = "Valid User Name"
            };
        }

        [TestMethod]
        public async Task ShouldBeValidCommand()
        {
            var validator = _provider.GetService<CreateUserCommandValidator>();

            var result = await validator.ValidateAsync(_createUserCommand);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public async Task ShouldThrowValidationException_MaxLengthName()
        {
            var validator = _provider.GetService<CreateUserCommandValidator>();

            _createUserCommand.Name = new string('p', 201);

            var result = await validator.ValidateAsync(_createUserCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == CreateUserCommandErrorMessages.MaxLengthName));
        }

        [TestMethod]
        public async Task ShouldThrowValidationException_EmptyName()
        {
            var validator = _provider.GetService<CreateUserCommandValidator>();

            _createUserCommand.Name = string.Empty;

            var result = await validator.ValidateAsync(_createUserCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == CreateUserCommandErrorMessages.EmptyName));
        }

        [TestMethod]
        public async Task ShouldThrowValidationException_EmptyBirthDate()
        {
            var validator = _provider.GetService<CreateUserCommandValidator>();

            _createUserCommand.BirthDate = null;

            var result = await validator.ValidateAsync(_createUserCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == CreateUserCommandErrorMessages.EmptyBirthDate));
        }

        [TestMethod]
        public async Task ShouldThrowValidationException_FutureBirthDate()
        {
            var validator = _provider.GetService<CreateUserCommandValidator>();

            _createUserCommand.BirthDate = new DateTime(2022, 05, 25);

            var result = await validator.ValidateAsync(_createUserCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == CreateUserCommandErrorMessages.FutureBirthDate));
        }



        [TestMethod]
        public async Task ShouldThrowValidationException_MaxLengthPassword()
        {
            var validator = _provider.GetService<CreateUserCommandValidator>();

            _createUserCommand.Password = new string('p', 201);

            var result = await validator.ValidateAsync(_createUserCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == CreateUserCommandErrorMessages.MaxLengthPassword));
        }


        [TestMethod]
        public async Task ShouldThrowValidationException_DifferentPasswords()
        {
            var validator = _provider.GetService<CreateUserCommandValidator>();

            _createUserCommand.Password = "invalidpw";

            var result = await validator.ValidateAsync(_createUserCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == CreateUserCommandErrorMessages.DifferentPasswords));
        }

        [TestMethod]
        public async Task ShouldThrowValidationException_EmptyPassword()
        {
            var validator = _provider.GetService<CreateUserCommandValidator>();

            _createUserCommand.Password = string.Empty;

            var result = await validator.ValidateAsync(_createUserCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == CreateUserCommandErrorMessages.EmptyPassword));
        }



        [TestMethod]
        public async Task ShouldThrowValidationException_EmptyConfirmPassword()
        {
            var validator = _provider.GetService<CreateUserCommandValidator>();

            _createUserCommand.ConfirmPassword = string.Empty;

            var result = await validator.ValidateAsync(_createUserCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == CreateUserCommandErrorMessages.EmptyConfirmPassword));
        }

        [TestMethod]
        public async Task ShouldThrowValidationException_EmptyEmail()
        {
            var validator = _provider.GetService<CreateUserCommandValidator>();

            _createUserCommand.Email = string.Empty;

            var result = await validator.ValidateAsync(_createUserCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == CreateUserCommandErrorMessages.EmptyEmail));
        }

        [TestMethod]
        public async Task ShouldThrowValidationException_MaxLengthEmail()
        {
            var validator = _provider.GetService<CreateUserCommandValidator>();

            _createUserCommand.Email = new string('p', 201);

            var result = await validator.ValidateAsync(_createUserCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == CreateUserCommandErrorMessages.MaxLengthEmail));
        }

        [TestMethod]
        public async Task ShouldThrowValidationException_UniqueEmail()
        {
            var validator = _provider.GetService<CreateUserCommandValidator>();

            _createUserCommand.Email = "mail@invalid.com";

            var result = await validator.ValidateAsync(_createUserCommand);

            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Any(x => x.ErrorMessage == CreateUserCommandErrorMessages.UniqueEmail));
        }
    }
}
