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
        private readonly ConnectionDbContext _connectionDbContext;
        public ClientRepository(ConnectionDbContext connectionDbContext)
        {
            _connectionDbContext = connectionDbContext;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            _connectionDbContext.Add(client);
            await _connectionDbContext.SaveChangesAsync();

            return client;
        }

        public async Task<Client> GetByIdAsync(int clientId)
        {
            return await _connectionDbContext.Client.FirstOrDefaultAsync(c => c.Id == clientId);
        }

        public async Task<ICollection<Client>> GetClientsAsync()
        {
            return await _connectionDbContext.Client.ToListAsync();

        }
        
    
    }
}
