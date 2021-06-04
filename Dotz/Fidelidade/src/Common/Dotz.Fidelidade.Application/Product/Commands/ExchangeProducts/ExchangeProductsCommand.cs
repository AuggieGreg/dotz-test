using Dotz.Fidelidade.Application.Common.Interfaces;
using Dotz.Fidelidade.Application.Common.Models;
using Dotz.Fidelidade.Application.Common.Security;
using Dotz.Fidelidade.Application.Dto;
using Dotz.Fidelidade.Domain.Interfaces;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Product.Commands.ExchangeProducts
{
    [Authorize(Roles = "User")]
    public class ExchangeProductsCommand : IRequestWrapper<ExchangedProductsResponse>
    {
        public ExchangeProductsCommand()
        {
            ProductRequests = new();
        }
        public List<ExchangeProductCommandItem> ProductRequests { get; set; }
    }

    public class ExchangeProductsCommandHandler : IRequestHandlerWrapper<ExchangeProductsCommand, ExchangedProductsResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IWalletBoundedContext _walletContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public ExchangeProductsCommandHandler(IApplicationDbContext context, IWalletBoundedContext walletContext, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _walletContext = walletContext;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task<ServiceResult<ExchangedProductsResponse>> Handle(ExchangeProductsCommand request, CancellationToken cancellationToken)
        {
            var response = new ExchangedProductsResponse();
            var wallet = await _walletContext.Wallets
                .SingleAsync(x => x.WalletId == _currentUserService.UserId, cancellationToken);

            foreach (var productRequest in request.ProductRequests)
            {
                var product = await _context.Products.SingleAsync(x => x.ProductId == productRequest.ProductId);
                wallet.ExchangeNewProduct(product, productRequest.Quantity);
                response.ExchangeResults.Add(new ExchangedProductResponseItem() { Product = _mapper.Map<ProductDto>(product) });
            }

            if (wallet.Balance < 0)
                return ServiceResult.Failed<ExchangedProductsResponse>(new ServiceError("Saldo insuficiente para concluir troca.", 666));

            await _context.SaveChangesAsync(cancellationToken);

            response.CurrentBalance = wallet.Balance;

            return ServiceResult.Success(response);
        }
    }
}
