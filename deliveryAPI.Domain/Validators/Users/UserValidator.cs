using FluentValidation;
using deliveryAPI.Domain.Entities.Users;

namespace deliveryAPI.Domain.Validators.Users;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("Nome é obrigatório!").MinimumLength(3).WithMessage("Nome deve ter no minímo 3 caracteres!"); ;
        RuleFor(user => user.Email).NotEmpty().WithMessage("E-mail é obrigatório!").EmailAddress().WithMessage("E-mail invalido");
        RuleFor(user => user.Password)
          .NotEmpty().WithMessage("Senha obrigatória!")
          .MinimumLength(8).WithMessage("Senha deve ter no minímo 8 caracteres!")
          .Matches("[0-9]").WithMessage("Senha deve conter pelo menos um número!")
          .Matches("[A-Z]").WithMessage("Senha deve conter no minímo uma letra maiúscula!")
          .Matches("[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>\\/?]").WithMessage("senha deve conter pelo menos um caractere especial!");
        RuleFor(user => user.CEP).NotEmpty().WithMessage("CEP obrigatório!");
        RuleFor(user => user.Street).NotEmpty().WithMessage("Nome da rua é obrigatório!");
        RuleFor(user => user.StreetNumber).NotEmpty().WithMessage("Número da casa é obrigatório!");
        RuleFor(user => user.Neighborhood).NotEmpty().WithMessage("Nome do bairro é obrigatório!");
    }
}
