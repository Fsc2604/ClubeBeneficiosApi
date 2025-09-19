using ClubeBeneficiosApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Application.Interfaces
{
    public interface IPurchaseService
    {
        Task<ReturnFrontService<PurchaseDto>> CreateAsync(PurchaseDto purchaseDto);

        Task<ReturnFrontService<PurchaseDto>> GetPurchaseByClientIdAsync(int Id);
        Task<ReturnFrontService<ICollection<PurchaseDto>>> GetAllPurchasesAsync();

    }
}
