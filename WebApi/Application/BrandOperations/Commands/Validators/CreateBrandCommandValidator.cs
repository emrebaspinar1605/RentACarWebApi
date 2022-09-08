using FluentValidation;
using WebApi.Application.BrandOperationsCommands.Commands;

namespace WebApi.Application.BrandOperationsCommands.Commands.Validators
{
  public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
  {
    public CreateBrandCommandValidator()
    {
      RuleFor(b => b.Model.Name).NotEmpty().NotNull().MinimumLength(2);
    }
  }
  
}