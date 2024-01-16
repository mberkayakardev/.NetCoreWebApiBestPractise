using AkarSoftware.ApiBestPractise.Core.DTOs;
using FluentValidation;

namespace AkarSoftware.ApiBestPractise.Services.Validations
{                                      // Fluent Validation kütüphanesinden gelecektir. 
    public class ProductDtoValidator : AbstractValidator<ProductDTO>
    {
        public ProductDtoValidator()
        {
            // Hem null olmasın hem boş olmasın
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("{PropertyName} alanı gereklidir.");

            // Bu alan kayıtta client gönderilmese dahi decimal olduğu için sıfır gelecektir.
            // default değerde olamaz olarak nu sebeple not null not empty yerine bizim range e ihtiyacımız vardır. 
            RuleFor(x => x.Price).ExclusiveBetween(1, decimal.MaxValue).WithMessage("{PropertyName} alanı boş yada 0 olamaz.");
            RuleFor(x => x.Stock).ExclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} alanı boş yada 0 olamaz.");
            RuleFor(x => x.CategoryId).ExclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} alanı boş yada 0 olamaz.");




        }

    }
}
