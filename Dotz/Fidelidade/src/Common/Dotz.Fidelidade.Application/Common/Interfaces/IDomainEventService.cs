using Dotz.Fidelidade.Domain.Common;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
