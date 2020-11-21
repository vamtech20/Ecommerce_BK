using FluentValidation;
using VamTech.Ecommerce.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Infraestructure.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Description)
                .NotNull()
                .WithMessage("La descripcion no puede ser nula");

           

        }
    }
}
