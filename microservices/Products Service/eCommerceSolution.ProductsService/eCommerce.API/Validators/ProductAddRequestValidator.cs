using FluentValidation;
using eCommerce.API.DTOs;

namespace eCommerce.API.Validators
{
    public class ProductAddRequestValidator : AbstractValidator<ProductAddRequest>
    {
        public ProductAddRequestValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("ProductName is required.")
                .MaximumLength(200);

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required.")
                .MaximumLength(100);

            RuleFor(x => x.UnitPrice)
                .GreaterThanOrEqualTo(0).When(x => x.UnitPrice.HasValue)
                .WithMessage("UnitPrice must be >= 0");

            RuleFor(x => x.UnitsInStock)
                .GreaterThanOrEqualTo(0).When(x => x.UnitsInStock.HasValue)
                .WithMessage("UnitsInStock must be >= 0");
        }
    }
}