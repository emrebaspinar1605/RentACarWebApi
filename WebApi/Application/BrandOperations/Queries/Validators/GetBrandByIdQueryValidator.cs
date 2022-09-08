using FluentValidation;

namespace WebApi.Application.BrandOperationsCommands.Queries.Validators
{
  public class GetBrandByIdQueryValidator : AbstractValidator<GetBrandByIdQuery>
  {
    public GetBrandByIdQueryValidator()
    {
      RuleFor(b => b.BrandId).NotEmpty().NotNull().GreaterThan(0);
    }
  }
}