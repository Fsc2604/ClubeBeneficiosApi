using ClubeBeneficiosAPi.Domain.Entities;
using ClubeBeneficiosAPi.Domain.Repositories;
using ClubeBeneficiosApi.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClubeBeneficiosApi.Infra.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
{
        private readonly ConnectionDbContext _connectionDbContext;
        public PurchaseRepository(ConnectionDbContext connectionDbContext)
        {
            _connectionDbContext = connectionDbContext;
        }


        public async Task<Purchase> CreateAsync(Purchase purchase)
        {
            _connectionDbContext.Add(purchase);
            await _connectionDbContext.SaveChangesAsync();
            return purchase;
        }


        public async Task<ICollection<Purchase>> GetAllAsync()
        {
           var allPurchases =  _connectionDbContext.Purchase.ToListAsync();

           return await allPurchases;
        }

        public async Task<ICollection<Purchase>> GetByClientIdAsync(int clientId)
        {
            var purchasesByClientId = _connectionDbContext.Purchase.Where(pur => pur.ClientId == clientId).ToListAsync();    

            return await purchasesByClientId;
        }

      
    }

}
