using Dotz.Fidelidade.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.User.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IDateTime _dateTime;
        private readonly IUserEntityQuerier _userQuerier;
        public CreateUserCommandValidator(IDateTime dateTime, IUserEntityQuerier userQuerier)
        {
            _dateTime = dateTime;
            _userQuerier = userQuerier;

            RuleFor(v => v.Name)
                .MaximumLength(200).WithMessage(CreateUserCommandErrorMessages.MaxLengthName)
                .NotEmpty().WithMessage(CreateUserCommandErrorMessages.EmptyName);

            RuleFor(v => v.BirthDate)
                .NotEmpty().WithMessage(CreateUserCommandErrorMessages.EmptyBirthDate)
                .Must(BeBeforeCurrentDate).WithMessage(CreateUserCommandErrorMessages.FutureBirthDate);

            RuleFor(v => v.Password)
                .MaximumLength(50).WithMessage(CreateUserCommandErrorMessages.MaxLengthPassword)
                .Equal(e => e.ConfirmPassword).WithMessage(CreateUserCommandErrorMessages.DifferentPasswords)
                .NotEmpty().WithMessage(CreateUserCommandErrorMessages.EmptyPassword);

            RuleFor(v => v.ConfirmPassword)
                .NotEmpty().WithMessage(CreateUserCommandErrorMessages.EmptyConfirmPassword);

            RuleFor(v => v.Email)
                .MaximumLength(200).WithMessage(CreateUserCommandErrorMessages.MaxLengthEmail)
                .NotEmpty().WithMessage(CreateUserCommandErrorMessages.EmptyEmail)
                .MustAsync(_userQuerier.HasUniqueEmail).WithMessage(CreateUserCommandErrorMessages.UniqueEmail);
        }

        private bool BeBeforeCurrentDate(DateTime? date)
        {
            return date < _dateTime.Now;
        }
    }

    public static class CreateUserCommandErrorMessages
    {
        public const string MaxLengthName = "O campo 'Nome' não pode ser maior que 200.";
        public const string EmptyName = "O campo 'Nome' deve ser informado.";
        public const string EmptyBirthDate = "O campo 'Data de Nascimento' deve ser informado.";
        public const string FutureBirthDate = "A 'Data de Nascimento' não pode ser futura.";
        public const string MaxLengthPassword = "O campo 'Senha' não pode ser maior que 50.";
        public const string DifferentPasswords = "As senhas não conferem.";
        public const string EmptyPassword = "O campo 'Senha' deve ser informado.";
        public const string EmptyConfirmPassword = "O campo 'Confirmação de Senha' deve ser informado.";
        public const string MaxLengthEmail = "O campo 'Email' não pode ser maior que 200.";
        public const string EmptyEmail = "O campo 'Email' deve ser informado.";
        public const string UniqueEmail = "Usuário já cadastrado para o e-mail.";
    }
}
