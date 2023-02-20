using FluentValidation;
using Projeto.Asp.Api.PousadaAsp.Domain.Entity;
using Projeto.Asp.Api.PousadaAsp.Domain.ViewModels;

namespace Projeto.Asp.Api.PousadaAsp.Domain.Validations
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                .Length(2, 80).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Email)
                   .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório.")
                   .EmailAddress().WithMessage("Por favor, informe um email válido.");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .Length(11).WithMessage("O CPF deve conter 11 dígitos")
                .Matches("^[0-9]*$").WithMessage("O CPF deve conter apenas números");
                
        }
    }
}
