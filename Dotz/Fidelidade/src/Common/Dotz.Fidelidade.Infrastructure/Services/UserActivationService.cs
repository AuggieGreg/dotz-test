using Dotz.Fidelidade.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Infrastructure.Services
{
    public class UserActivationService : IUserActivationService
    {
        public Guid GetUserIdFromCode(string code)
        {
            Guid userId;
            if (Guid.TryParse(code, out userId))
                return userId;
            return Guid.Empty;
        }

        public void SendActivationCode(Guid userId, string name)
        {
        }
    }
}
