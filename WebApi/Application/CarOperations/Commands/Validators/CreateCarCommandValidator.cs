using FluentValidation;

namespace WebApi.Application.CarOperationsCommands.Commands.Validators
{
  public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
  {
    public CreateCarCommandValidator()
    {
      RuleFor(c => c.Model.BrandId).NotEmpty().NotNull().GreaterThan(0);
      RuleFor(c => c.Model.ColorId).NotEmpty().NotNull().GreaterThan(0);
      RuleFor(c => c.Model.CarName).NotEmpty().NotNull().MinimumLength(3);
    }
  }
}