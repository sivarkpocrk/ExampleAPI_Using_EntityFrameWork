using FluentValidation;
using CustomApi.Models;

namespace CustomApi.Validators // Ensure this namespace is correct
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
}
