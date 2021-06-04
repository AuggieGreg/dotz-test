using Dotz.Fidelidade.Application.ProductOrder.Queries;
using FluentValidation;
using Dotz.Fidelidade.Domain.Enums;
using System;

namespace Dotz.Fidelidade.Application.Product.Queries.GetAllProductsWithPagination
{
    public class GetProductOrderWithPaginationByStatusValidator : AbstractValidator<GetProductOrderWithPaginationByStatus>
    {
        public GetProductOrderWithPaginationByStatusValidator()
        {
            RuleFor(x => x.DeliveryStatus)
                .NotEmpty().WithMessage(GetProductOrderWithPaginationByStatusValidatorErrorMessages.EmptyDeliveyStatus)
                .Must(ConvertableToDeliveryStatusEnum).WithMessage(GetProductOrderWithPaginationByStatusValidatorErrorMessages.NotConvertableToDeliveryStatusEnum);

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage(GetProductOrderWithPaginationByStatusValidatorErrorMessages.GreaterThanOrEqualToPageNumber);

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage(GetProductOrderWithPaginationByStatusValidatorErrorMessages.GreaterThanOrEqualToPageSize);
        }

        private static bool ConvertableToDeliveryStatusEnum(string deliveryStatus) {
            return Enum.TryParse(deliveryStatus, out DeliveryStatus result);
        }
    }

    public static class GetProductOrderWithPaginationByStatusValidatorErrorMessages
    {
        public const string GreaterThanOrEqualToPageNumber = "O número da página deve ser maior ou igual a 1.";

        public const string GreaterThanOrEqualToPageSize = "O número de páginas deve ser maior ou igual a 1.";

        public const string NotConvertableToDeliveryStatusEnum = "O 'Status de Entrega' solicitado não é válido para busca.";

        public const string EmptyDeliveyStatus = "O 'Status de Entrega' deve ser informado.";
    }
}
