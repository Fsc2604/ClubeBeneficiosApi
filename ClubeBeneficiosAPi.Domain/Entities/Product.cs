using ClubeBeneficiosAPi.Domain.ValidationsDomain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosAPi.Domain.Entities
{
   public sealed class Product {

        public int Id { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<Purchase> Purchases { get; private set; }


        public Product(int id, string name, string description, decimal price)
        {
          Validation(name, description, price);
        }

        /// <summary> Método para validação caso algum atributo esteja vazio < /summary>
        private void Validation(string name, string description, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(description), "Descrição deve ser informada");
            DomainValidationException.When(price <= 0, "Preço deve ser informado");

            Name = name;
            Description = description;
            Price = price;
        }
    }
}
