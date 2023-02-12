using FluentValidation;
using POS.Api.CHQV.Commands;

namespace POS.Api.CHQV.Validators
{
    public class CreateInventoryValidator : AbstractValidator<CreateInventory>
    {
        public CreateInventoryValidator()
        {
            RuleFor(x => x.Item).NotNull();
            RuleFor(x => x.Item.Price).NotNull().GreaterThan(0);
            RuleFor(x => x.Item.Size).NotEmpty();
            RuleFor(x => x.Item.Name).NotEmpty();
        }
    }
}
