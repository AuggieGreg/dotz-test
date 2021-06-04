using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Dto;
using Dotz.Fidelidade.Domain.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Wallet.Queries.GetUserWallet
{
    public class GetUserWalletQuery : IRequestWrapper<WalletDto>
    {

    }

    public class GetUserWalletQueryHandler : IRequestHandlerWrapper<GetUserWalletQuery, WalletDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWalletBoundedContext _walletContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetUserWalletQueryHandler(IApplicationDbContext context, IWalletBoundedContext walletContext, ICurrentUserService currentUserService, IMapper mapper)
        {
            this._context = context;
            this._walletContext = walletContext;
            this._currentUserService = currentUserService;
            this._mapper = mapper;
        }
        public async Task<ServiceResult<WalletDto>> Handle(GetUserWalletQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _walletContext.Wallets
                .SingleAsync(x => x.WalletId == _currentUserService.UserId, cancellationToken);

            return ServiceResult.Success(_mapper.Map<WalletDto>(wallet));
        }
    }
}
