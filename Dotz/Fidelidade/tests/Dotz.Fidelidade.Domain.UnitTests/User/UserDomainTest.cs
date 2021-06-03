using Dotz.Fidelidade.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Dotz.Fidelidade.Domain.UnitTests
{
    [TestClass]
    public class UserDomainTest
    {
        private readonly UserEntity _user;
        private readonly Guid _userId;
        private readonly Guid _userAddress1Id;
        private readonly Guid _userAddress2Id;

        public UserDomainTest()
        {
            _userId = Guid.NewGuid();
            _userAddress1Id = Guid.NewGuid();
            _userAddress2Id = Guid.NewGuid();
            _user = new UserEntity(_userId, "Augusto", "User", "hashtest", "augusto@augusto.mail", DateTime.Now, true);
            _user.AddOrUpdateAddress(_userAddress1Id, "12", "Rua teste", 13, "Casa 2", true, _user.UserId);
            _user.AddOrUpdateAddress(_userAddress2Id, "14", "Rua teste", 15, "Casa 3", false, _user.UserId);
        }

        [TestMethod]
        public void AddOrUpdateBehavior_Test()
        {
            Assert.IsTrue(_user.UserAddresses.Any(x => x.AddressId == _userAddress1Id && x.IsMain));
        }

        [TestMethod]
        public void AddOrUpdateBehavior_AddTest()
        {
            var newUserAddressId = Guid.NewGuid();
            _user.AddOrUpdateAddress(newUserAddressId, "12", "Rua teste", 13, "Casa 2", true, _user.UserId);
            Assert.IsNotNull(_user.UserAddresses.SingleOrDefault(x => x.AddressId == newUserAddressId && x.IsMain));
        }

        [TestMethod]
        public void AddOrUpdateBehavior_UpdateTest()
        {
            _user.AddOrUpdateAddress(_userAddress2Id, "change", "change", 13, "change", true, _user.UserId);
            Assert.IsNotNull(_user.UserAddresses.SingleOrDefault(x => x.AddressId == _userAddress2Id && x.IsMain));
        }
    }
}
