using Dotz.Fidelidade.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Product.Commands.ExchangeProducts
{
    public class ExchangeProductsCommandValidator : AbstractValidator<ExchangeProductsCommand>
    {
        public ExchangeProductsCommandValidator(IProductQuerier productQuerier)
        {
            RuleFor(f => f.ProductRequests).ForEach(f => f.SetValidator(new ExchangeProductCommandItemValidator(productQuerier)));
        }
    }
}
