using ClubeBeneficiosAPi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosAPi.Domain.Repositories
{
    public interface IClientRepository
    {
       
            //Pega uma lista de Clientes
            Task<ICollection<Client>> GetClientsAsync();

            //Cria uma Cliente
            Task<Client> CreateAsync(Client client);

            //Deleta uma Cliente
            Task DeleteAsync(Client client);

    }
}
