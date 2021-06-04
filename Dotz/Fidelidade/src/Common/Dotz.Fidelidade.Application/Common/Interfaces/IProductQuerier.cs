using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Common.Interfaces
{
    public interface IProductQuerier
    {
        Task<bool> ExistsById(Guid productId, CancellationToken cancelationToken);
    }
}
