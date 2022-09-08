using FluentValidation;

namespace WebApi.Application.ColorOperationsCommands.Commands.Validator
{
  public class DeleteColorCommandValidator : AbstractValidator<DeleteColorCommand>
  {
    public  DeleteColorCommandValidator()
    {
      RuleFor(c => c.ColorId).GreaterThan(0).NotEmpty().NotNull();
    }
  }
}