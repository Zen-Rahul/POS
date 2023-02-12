using FluentValidation;
using POS.Api.CHQV.Queries;

namespace POS.Api.CHQV.Validators
{
    public class GetOrderValidator : AbstractValidator<GetOrder>
    {
        public GetOrderValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
