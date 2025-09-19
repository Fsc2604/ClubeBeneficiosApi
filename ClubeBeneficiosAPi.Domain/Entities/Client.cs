using ClubeBeneficiosAPi.Domain.ValidationsDomain;
using ClubeBeneficiosAPi.Domain.VlidationsDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosAPi.Domain.Entities
{
    public sealed class Client
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }


        public ICollection<Purchase> Purchases { get; private set; }


        public UserPermission Permission { get; set; }


        public Client(string clientName, string email, string senha)
        {

            Validation(clientName, email, senha);


        }
        /// <summary> Método para validação caso algum atributo esteja vazio < /summary>
        private void Validation(string clientName, string email, string password)
        {
            DomainValidationException.When(string.IsNullOrWhiteSpace(clientName), "Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrWhiteSpace(email), "Email deve ser informado");
            DomainValidationException.When(string.IsNullOrWhiteSpace(password), "Senha deva ser informada");


            ClientName = clientName;
            Email = email;
            Password = password;
        }

    }
}
