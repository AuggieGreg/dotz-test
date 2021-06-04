using FluentValidation;
using System;

namespace Dotz.Fidelidade.Application.Product.Queries.GetAllProductsWithPagination
{
    public class GetAllProductsWithPaginationQueryValidator : AbstractValidator<GetAllProductsWithPaginationQuery>
    {
        public GetAllProductsWithPaginationQueryValidator()
        {
            RuleFor(x => x.CategoryId)
                .Must(NotBeEmptyIfSet).WithMessage(GetAllProductsWithPaginationQueryValidatorErrorMessages.NotBeEmptyIfSetCategoryId);

            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1).WithMessage(GetAllProductsWithPaginationQueryValidatorErrorMessages.GreaterThanOrEqualToPageNumber);

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage(GetAllProductsWithPaginationQueryValidatorErrorMessages.GreaterThanOrEqualToPageSize);
        }

        private static bool NotBeEmptyIfSet(Guid? categoryId) {
            return !categoryId.HasValue || categoryId.Value != Guid.Empty;
        }
    }

    public static class GetAllProductsWithPaginationQueryValidatorErrorMessages
    {
        public const string GreaterThanOrEqualToPageNumber = "O número da página deve ser maior ou igual a 1.";

        public const string GreaterThanOrEqualToPageSize = "O número de páginas deve ser maior ou igual a 1.";

        public const string NotBeEmptyIfSetCategoryId = "O identificador de 'Categoria' não poder ser vazio quando informado.";
    }
}
