using FluentValidation;

namespace WebApi.Application.CarOperationsCommands.Commands.Validators
{
  public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommand>
  {
    public DeleteCarCommandValidator()
    {
      RuleFor(c => c.CarId).NotEmpty().NotNull().GreaterThan(0);
    }
  }
}