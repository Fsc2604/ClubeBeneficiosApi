using ClubeBeneficiosApi.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Application.ValidationDtos
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {

        public ProductDtoValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(70).WithMessage("Descrição não pode passar de 70 caracteres")
                .WithMessage("Nome do Produto deve ser informado!");

            RuleFor(x => x.Description)
               .NotEmpty()
               .NotNull()
               .MaximumLength(160).WithMessage("Descrição não pode passar de 160 caracteres")
               .WithMessage("Descricao do Produto deve ser informada!");

            RuleFor(x => x.Price)
               .GreaterThan(0).WithMessage("Preço deve ser maior que zero")
               .WithMessage("O preço deve ser informado!");
        }
    }
}
