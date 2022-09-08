using FluentValidation;

namespace WebApi.Application.ColorOperationsCommands.Commands.Validator
{
  public class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
  {
    public  UpdateColorCommandValidator()
    {
      RuleFor(c => c.Model.Name).MinimumLength(2).NotEmpty().NotNull();
      RuleFor(c => c.ColorId).GreaterThan(0).NotEmpty().NotNull();
    }
  }
}