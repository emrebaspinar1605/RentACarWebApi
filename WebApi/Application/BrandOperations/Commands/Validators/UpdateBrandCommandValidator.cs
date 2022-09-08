using FluentValidation;
using WebApi.Application.BrandOperationsCommands.Commands;

namespace WebApi.Application.BrandOperationsCommands.Commands.Validators
{
  public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
  {
    public UpdateBrandCommandValidator()
    {
      RuleFor(b => b.Model.Name).NotEmpty().NotNull().MinimumLength(2);
      RuleFor(b => b.BrandId).NotEmpty().NotNull().GreaterThan(0); 
    }
  }
  
}