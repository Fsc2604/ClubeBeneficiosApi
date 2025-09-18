using ClubeBeneficiosApi.Infra.Data.Context;
using ClubeBeneficiosAPi.Domain.Entities;
using ClubeBeneficiosAPi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Infra.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ConnectionDbContext _ConnectionDbContext;
        public ClientRepository(ConnectionDbContext connectionDbContext)
        {
            _ConnectionDbContext = connectionDbContext;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            _ConnectionDbContext.Add(client);
            await _ConnectionDbContext.SaveChangesAsync();

            return client;
        }

        public async Task DeleteAsync(Client client)
        {
            _ConnectionDbContext.Remove(client);
            await _ConnectionDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Client>> GetClientsAsync()
        {
            return await _ConnectionDbContext.Client.ToListAsync();

        }
        
    
    }
}
