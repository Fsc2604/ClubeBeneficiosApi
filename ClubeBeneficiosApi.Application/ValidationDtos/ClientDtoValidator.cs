using ClubeBeneficiosApi.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Application.ValidationDtos
{
   
        public class ClientDtoValidator : AbstractValidator<ClientDto>
        {
            public ClientDtoValidator()
            {
                RuleFor(x => x.ClientName)
                    .NotEmpty()
                    .NotNull()
                    .MaximumLength(70).WithMessage("Descrição não pode passar de 70 caracteres")
                    .WithMessage("Nome deve ser informado");

                RuleFor(x => x.Email)
                   .NotEmpty()
                   .NotNull()
                   .EmailAddress().WithMessage("Email em formato inválido")
                   .WithMessage("Email deve ser informado");

                RuleFor(x => x.Password)
                   .NotEmpty()
                   .NotNull()
                   .MinimumLength(8).WithMessage("Password deve ter no mínimo 8 caracteres")
                   .WithMessage("Password deve ser informado");
            }
        }
 
}
