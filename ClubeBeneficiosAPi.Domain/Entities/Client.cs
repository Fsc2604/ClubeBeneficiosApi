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
        public string Name { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }


        public ICollection<Purchase> Purchases { get; private set; }


        public Client(string Name, string Cpf, string Senha)
        {

            Validation(Name, Cpf, Senha);


        }
        /// <summary> Método para validação caso algum atributo esteja vazio < /summary>
        private void Validation(string name, string email, string senha)
        {
            DomainValidationException.When(string.IsNullOrWhiteSpace(name), "Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrWhiteSpace(email), "Cpf deve ser informado");
            DomainValidationException.When(string.IsNullOrWhiteSpace(senha), "Senha deva ser informada");


            Name = name;
            Email = email;
            Senha = senha;
        }

    }
}
