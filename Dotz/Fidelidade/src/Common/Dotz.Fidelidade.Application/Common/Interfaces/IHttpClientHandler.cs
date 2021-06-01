using System.Threading;
using System.Threading.Tasks;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Domain.Enums;

namespace Dotz.Fidelidade.Application.Common.Interfaces
{
    public interface IHttpClientHandler
    {
        Task<ServiceResult<TResult>> GenericRequest<TRequest, TResult>(string clientApi, string url,
            CancellationToken cancellationToken,
            MethodType method = MethodType.Get,
            TRequest requestEntity = null)
            where TResult : class where TRequest : class;
    }
}