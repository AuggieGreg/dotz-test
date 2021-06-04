using Dotz.Fidelidade.Application.Common.Interfaces;
using FluentValidation;

namespace Dotz.Fidelidade.Application.Product.Commands.ExchangeProducts
{
    public class ExchangeProductCommandItemValidator : AbstractValidator<ExchangeProductCommandItem>
    {
        private readonly IProductQuerier _productQuerier;
        public ExchangeProductCommandItemValidator(IProductQuerier productQuerier)
        {
            _productQuerier = productQuerier;

            RuleFor(r => r.ProductId)
                .NotEmpty().WithMessage(ExchangeProductCommandItemErrorMessages.EmptyProductId)
                .MustAsync(_productQuerier.ExistsById).WithMessage(ExchangeProductCommandItemErrorMessages.NotExistentProductId);

            RuleFor(r => r.Quantity)
                .GreaterThan(0).WithMessage(ExchangeProductCommandItemErrorMessages.GreaterThanOrEqualToQuantity);
        }
    }

    public static class ExchangeProductCommandItemErrorMessages
    {
        public const string EmptyProductId = "O identificador do 'Produto' deve ser informado.";
        public const string NotExistentProductId = "Identificador de 'Produto' não existente.";
        public const string GreaterThanOrEqualToQuantity = "A 'Quantidade' deve ser maior ou igual a 1.";
    }
}
