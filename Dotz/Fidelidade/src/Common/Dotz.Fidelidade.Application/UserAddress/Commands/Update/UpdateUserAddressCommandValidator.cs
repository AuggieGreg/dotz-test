using FluentValidation;

namespace Dotz.Fidelidade.Application.UserAddress.Commands.Update
{
    public class UpdateUserAddressCommandValidator : AbstractValidator<UpdateUserAddressCommand>
    {
        public UpdateUserAddressCommandValidator()
        {
            RuleFor(x => x.AddressId)
                .NotEmpty().WithMessage(UpdateUserAddressCommandErrorMessages.EmptyAddressId);

            RuleFor(x => x.Address)
                .MaximumLength(500).WithMessage(UpdateUserAddressCommandErrorMessages.MaximumLengthAddress)
                .NotEmpty().WithMessage(UpdateUserAddressCommandErrorMessages.EmptyAddress);

            RuleFor(x => x.Complement)
                .MaximumLength(200).WithMessage(UpdateUserAddressCommandErrorMessages.MaximumLengthComplement);
        }
    }

    public static class UpdateUserAddressCommandErrorMessages
    {
        public const string EmptyAddressId = "O identificador de 'Endereço' deve ser informado.";
        public const string MaximumLengthAddress = "O campo 'Endereço' não pode ser maior que 500.";
        public const string EmptyAddress = "O campo 'Endereço' deve ser informado.";
        public const string MaximumLengthComplement = "O campo 'Complemento' não pode ser maior que 200.";
    }
}
