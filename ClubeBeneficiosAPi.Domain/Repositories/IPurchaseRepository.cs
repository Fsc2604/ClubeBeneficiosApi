using ClubeBeneficiosAPi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosAPi.Domain.Repositories
{
    public interface IPurchaseRepository
    {
      


        //Pega uma lista de Compras
        Task<ICollection<Purchase>> GetAllAsync();

        // Pega todas as compras de um cliente específico
        Task<ICollection<Purchase>> GetByClientIdAsync(int clientId);

        //Cria uma Compra
        Task<Purchase> CreateAsync(Purchase purchase);

        //Deleta uma Compra
        Task DeleteAsync(Purchase purchase);
    }
}
