using FluentValidation;

namespace WebApi.Application.ColorOperationsCommands.Queries.Validators
{
  public class GetColorByIdQueryValidator : AbstractValidator<GetColorByIdQuery>
  {
    public GetColorByIdQueryValidator()
    {
      RuleFor(c => c.ColorId).NotEmpty().NotNull().GreaterThan(0);
    }
  }
}