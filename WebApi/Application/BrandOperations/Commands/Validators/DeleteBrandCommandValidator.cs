using FluentValidation;
using WebApi.Application.BrandOperationsCommands.Commands;

namespace WebApi.Application.BrandOperationsCommands.Commands.Validators
{
  public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
  {
    public DeleteBrandCommandValidator()
    {
      RuleFor(b => b.BrandId).NotEmpty().NotNull().GreaterThan(0);
    }
  }
  
}