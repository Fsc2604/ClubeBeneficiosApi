using ClubeBeneficiosAPi.Domain.ClubeBeneficiosAPi.Domain.Enums;
using ClubeBeneficiosAPi.Domain.ValidationsDomain;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosAPi.Domain.Entities
{
    public sealed class UserPermission
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public UserRole Role { get; private set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }


        public UserPermission(string email, string passwordHash, UserRole role)
        {
            Validation(email, passwordHash, role);
        }


        public void SetPasswordHash(string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("PasswordHash não pode ser vazio");

            PasswordHash = passwordHash;
        }

        private void Validation(string email, string passwordHash, UserRole role)
        {
            DomainValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(passwordHash), "Password deve ser informado");
            DomainValidationException.When(!Enum.IsDefined(typeof(UserRole), role), "Permissão inválida");

            Email = email;
            PasswordHash = passwordHash;
            Role = role;
       
        }
    }
}