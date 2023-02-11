using FluentValidation;
using POS.Api.CHQV.Commands;

namespace POS.Api.CHQV.Validators
{
    public class PlaceOrderValidator : AbstractValidator<PlaceOrder>
    {
        public PlaceOrderValidator()
        {
            RuleFor(x => x.Order).NotNull();
            RuleFor(x => x.Order.User).NotNull();
            RuleFor(x => x.Order.User.Email).NotNull().EmailAddress();
            RuleFor(x => x.Order.User.DeliveryAddress).NotEmpty();
            RuleFor(x => x.Order.User.Name).NotEmpty();
            RuleFor(x => x.Order.Pizzas).NotNull();
            RuleFor(x => x.Order.User.MobileNumber).NotEmpty().MinimumLength(10).MaximumLength(10);
        }
    }
}
