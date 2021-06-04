using Dotz.Fidelidade.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Domain.Interfaces
{
    public interface IWalletBoundedContext
    {
        IQueryable<WalletEntity> Wallets { get; }
    }
}
