using ClubeBeneficiosApi.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Application.ValidationDtos
{
    public class PurchaseDtoValidator : AbstractValidator<PurchaseDto>
    {
        public PurchaseDtoValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(70).WithMessage("Nome do Produto não pode passar de 70 caracteres")
                .WithMessage("Nome do produto  deve ser informado");

            RuleFor(x => x.ClientName)
               .NotEmpty()
               .NotNull()
               .MaximumLength(70).WithMessage("Nome do Cliente não pode passar de 70 caracteres")
               .WithMessage("Nome do Cliente deve ser informado");


            RuleFor(x => x.Price)
               .NotEmpty()
               .NotNull()
               .WithMessage("O preço deve ser informado")
               .GreaterThan(0).WithMessage("Preço deve ser maior que zero");

            RuleFor(x => x.Description)
            .MaximumLength(100).WithMessage("Descrição não pode passar de 100 caracteres");


        }
    }
}
