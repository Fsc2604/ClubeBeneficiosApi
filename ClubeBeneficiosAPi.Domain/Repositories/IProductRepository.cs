using ClubeBeneficiosAPi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosAPi.Domain.Repositories
{
    public interface IProducttRepository
    {

        //Pega uma lista de produtos
        Task<ICollection<Product>> GetProductsAsync();

        //Cria uma produto
        Task<Product> CreateAsync(Product product);

        // Pega produtos filtrando por preço mínimo e máximo
        Task<ICollection<Product>> GetProductsByPriceAsync(decimal minPrice, decimal maxPrice);

        Task<Product> GetByIdAsync(int productId);

    }
}
