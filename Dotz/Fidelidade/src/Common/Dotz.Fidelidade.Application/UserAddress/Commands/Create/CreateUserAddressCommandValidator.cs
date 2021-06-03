using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.UserAddress.Commands.Create
{
    public class CreateUserAddressCommandValidator : AbstractValidator<CreateUserAddressCommand> 
    {
        public CreateUserAddressCommandValidator()
        {
            RuleFor(x => x.Address)
                .MaximumLength(500).WithMessage(CreateUserAddressCommandErrorMessages.MaximumLengthAddress)
                .NotEmpty().WithMessage(CreateUserAddressCommandErrorMessages.EmptyAddress);

            RuleFor(x => x.Complement)
                .MaximumLength(200).WithMessage(CreateUserAddressCommandErrorMessages.MaximumLengthComplement);
        }
    }

    public static class CreateUserAddressCommandErrorMessages
    {
        public const string MaximumLengthAddress = "O campo 'Endereço' não pode ser maior que 500.";
        public const string EmptyAddress = "O campo 'Endereço' deve ser informado.";
        public const string MaximumLengthComplement = "O campo 'Complemento' não pode ser maior que 200.";
    }
}
