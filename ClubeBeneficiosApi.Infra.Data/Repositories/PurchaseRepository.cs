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
        private readonly ConnectionDbContext _ConnectionDbContext;
        public PurchaseRepository(ConnectionDbContext connectionDbContext)
        {
            _ConnectionDbContext = connectionDbContext;
        }


        public async Task<Purchase> CreateAsync(Purchase purchase)
        {
            _ConnectionDbContext.Add(purchase);
            await _ConnectionDbContext.SaveChangesAsync();
            return purchase;
        }



        public async Task DeleteAsync(Purchase purchase)
        {
            _ConnectionDbContext.Remove(purchase);
            await _ConnectionDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Purchase>> GetAllAsync()
        {
           var allPurchases =  _ConnectionDbContext.Purchase.ToListAsync();

           return await allPurchases;
        }

        public async Task<ICollection<Purchase>> GetByClientIdAsync(int clientId)
        {
            var purchasesByClientId = _ConnectionDbContext.Purchase.Where(pur => pur.ClientId == clientId).ToListAsync();    

            return await purchasesByClientId;
        }

      
    }

}
