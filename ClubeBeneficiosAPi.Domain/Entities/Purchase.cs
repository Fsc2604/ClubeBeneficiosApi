using ClubeBeneficiosAPi.Domain.ValidationsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosAPi.Domain.Entities
{
    public sealed class Purchase
    {

        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int ClientId { get; private set; }
  
        public Client Client { get; private set; }
        public Product Product { get; private set; }


        public Purchase(int productId, int clientId)
        {
           Validation(productId, clientId);
        }


        /// <summary> Método para validação caso algum atributo esteja vazio < /summary>
        private void Validation(int productId, int clientId)
        {
            DomainValidationException.When(productId <= 0, "Id Produto deve ser informado");
            DomainValidationException.When(clientId <= 0, "Id Cliente deve ser informado");
      

            ProductId = productId;
            ClientId = clientId;
       
        }
    }
}
