using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Domain.Enums
{
    public enum DeliveryStatus
    {
        NotSet,
        Created,
        Preparing,
        InTransit,
        Delivered,
        InTransitRetry,
        Lost,
        Cancelled
    }
}
