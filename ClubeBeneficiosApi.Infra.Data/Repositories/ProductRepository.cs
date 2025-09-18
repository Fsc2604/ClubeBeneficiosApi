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
    public class ProductRepository : IProducttRepository
    {

        private readonly ConnectionDbContext _ConnectionDbContext;

        public ProductRepository(ConnectionDbContext connectionDbContext)
        {
            _ConnectionDbContext = connectionDbContext;
        }
 

        public async Task<Product> CreateAsync(Product product)
        {
            _ConnectionDbContext.Add(product);
            await _ConnectionDbContext.SaveChangesAsync();
            return product; 
        }

        public async Task DeleteAsync(Product product)
        {
            _ConnectionDbContext.Remove(product);
            await _ConnectionDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetProductsAsync()
        {
            return await _ConnectionDbContext.Product.ToListAsync();
        }

        public  async Task<ICollection<Product>> GetProductsByPriceAsync(decimal minPrice, decimal maxPrice)
        {
            var Filterproducts  = _ConnectionDbContext.Product.Where(pr => pr.Price >= minPrice && pr.Price <= maxPrice)
                .OrderBy(pr =>  pr.Price)
                .ToListAsync();

            return await Filterproducts;
        }

       
    }
}
