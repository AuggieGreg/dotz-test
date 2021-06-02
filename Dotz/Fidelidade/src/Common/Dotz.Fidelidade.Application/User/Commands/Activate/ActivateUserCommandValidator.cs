using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.User.Commands.Activate
{
    public class ActivateUserCommandValidator : AbstractValidator<ActivateUserCommand>
    {
        public ActivateUserCommandValidator()
        {
            RuleFor(x => x.SecretCode)
                .Must(x => x.Length == 36).WithMessage(ActivateUserCommandErrorMessages.ExactLengthSecretCode);
        }
    }

    public static class ActivateUserCommandErrorMessages
    {
        public const string ExactLengthSecretCode = "O tamanho do 'Código Secreto' deve ser 36.";
    }
}
