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

        private readonly ConnectionDbContext _connectionDbContext;

        public ProductRepository(ConnectionDbContext connectionDbContext)
        {
            _connectionDbContext = connectionDbContext;
        }
 

        public async Task<Product> CreateAsync(Product product)
        {
            _connectionDbContext.Add(product);
            await _connectionDbContext.SaveChangesAsync();
            return product; 
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _connectionDbContext.Product.FirstOrDefaultAsync(c => c.Id == productId);
        }

        public async Task<ICollection<Product>> GetProductsAsync()
        {
            return await _connectionDbContext.Product.ToListAsync();
        }

        public  async Task<ICollection<Product>> GetProductsByPriceAsync(decimal minPrice, decimal maxPrice)
        {
            var Filterproducts  = _connectionDbContext.Product.Where(pr => pr.Price >= minPrice && pr.Price <= maxPrice)
                .OrderBy(pr =>  pr.Price)
                .ToListAsync();

            return await Filterproducts;
        }

       
    }
}
