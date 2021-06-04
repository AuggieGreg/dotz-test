using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Common.Interfaces
{
    public interface IProductCategoryRecursiveQuerier
    {
        IEnumerable<Guid> GetAllCategoryIdsByParentId(Guid parentCategoryId);
    }
}
