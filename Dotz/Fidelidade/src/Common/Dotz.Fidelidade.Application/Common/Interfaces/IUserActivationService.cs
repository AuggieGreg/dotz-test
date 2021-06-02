using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Common.Interfaces
{
    public interface IUserActivationService
    {
        void SendActivationCode(Guid userId, string name);

        Guid GetUserIdFromCode(string code);
    }
}
