using FluentValidation;

namespace WebApi.Application.ColorOperationsCommands.Commands.Validator
{
  public class CreateColorCommandValidator : AbstractValidator<CreateColorCommand>
  {
    public  CreateColorCommandValidator()
    {
      RuleFor(c => c.Model.Name).MinimumLength(2).NotEmpty().NotNull();
    }
  }
}