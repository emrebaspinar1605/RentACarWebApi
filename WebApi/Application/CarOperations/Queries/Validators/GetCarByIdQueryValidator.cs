using FluentValidation;

namespace WebApi.Application.CarOperationsCommands.Queries.Validators
{
  public class GetCarByIdQueryValidator : AbstractValidator<GetCarByIdQuery>
  {
    public GetCarByIdQueryValidator()
    {
      RuleFor(c => c.CarId).NotEmpty().NotNull().GreaterThan(0);
    }
  }
}