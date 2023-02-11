using FluentValidation;
using POS.Api.CHQV.Queries;

namespace POS.Api.CHQV.Validators
{
    public class GetItemsValidator : AbstractValidator<GetItems>
    {
        public GetItemsValidator()
        {
            RuleFor(c => c.InventoryType).NotEmpty().WithMessage("Inventory type is required to get items");
        }
    }
}
