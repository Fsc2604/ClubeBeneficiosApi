using ClubeBeneficiosApi.Application;
using ClubeBeneficiosApi.Application.DTOs;
using ClubeBeneficiosApi.Application.Interfaces;
using ClubeBeneficiosAPi.Domain.ValidationsDomain;
using Microsoft.AspNetCore.Mvc;

namespace ClubeBeneficios.API.Controllers
{
    public class PurchaseController : BaseControllers
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PurchaseDto purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.CreateAsync(purchaseDTO);
                if (result.IsSucess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ReturnFrontService.Fail(ex.Message);
                return BadRequest(result);
            }

        }
        [HttpGet]
        public async Task<ActionResult> GetAllPurchasesAsync()
        {

            var result = await _purchaseService.GetAllPurchasesAsync();
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int clientId)
        {

            var result = await _purchaseService.GetPurchaseByClientIdAsync(clientId);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);

        }

    }
}
