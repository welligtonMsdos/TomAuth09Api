using FluentValidation;
using TomAuthApi.src.Domain.Model;

namespace TomAuthApi.src.Domain.Validation;

public class UserCreateValidation : AbstractValidator<User>
{
    public UserCreateValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Nome não pode ser vazio!");
        RuleFor(x => x.Name).MinimumLength(3).WithMessage("Nome tem que ter no mínimo 3 caracteres");
        RuleFor(x => x.Name).MaximumLength(50).WithMessage("Nome tem que ter no máximo 50 caracteres");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email não pode ser vazio!");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Email inválido!");
        RuleFor(x => x.Email).MinimumLength(12).WithMessage("Email tem que ter no mínimo 12 caracteres");
        RuleFor(x => x.Email).MaximumLength(50).WithMessage("Email tem que ter no máximo 50 caracteres");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Senha não pode ser vazia!");
        RuleFor(x => x.Password).MinimumLength(6).WithMessage("Senha tem que ter no mínimo 6 caracteres");
    }
}
