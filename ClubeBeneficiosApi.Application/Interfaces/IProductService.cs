using ClubeBeneficiosApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Application.Interfaces
{
    public interface IProductService
    {

   
        Task<ReturnFrontService<ProductDto>> CreateAsync(ProductDto productDTO);

    
        Task<ReturnFrontService<ICollection<ProductDto>>> GetAllProductsAsync();

        Task<ReturnFrontService<ICollection<ProductDto>>> GetProductsByFilteringAsync(decimal minPrice, decimal maxPrice);

        Task<ReturnFrontService<ClientDto>> GetByIdAsync(int productId);
    }
}
