using AutoMapper;
using ClubeBeneficiosApi.Application.DTOs;
using ClubeBeneficiosApi.Application.Interfaces;
using ClubeBeneficiosApi.Application.ValidationDtos;
using ClubeBeneficiosAPi.Domain.Entities;
using ClubeBeneficiosAPi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProducttRepository _productRepository;
        private readonly IMapper _mapper;

        public PurchaseService(IPurchaseRepository purchaseRepository, IClientRepository clientRepository, IProducttRepository producttRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _clientRepository =   clientRepository;
            _productRepository = producttRepository;
            _mapper = mapper;
        }

        public async Task<ReturnFrontService<PurchaseDto>> CreateAsync(PurchaseDto purchaseDto)
        {
            if (purchaseDto == null)
                return ReturnFrontService.Fail<PurchaseDto>("Objeto Deve ser informado!");

            var validate = new PurchaseDtoValidator().Validate(purchaseDto);
            if (!validate.IsValid)
                return ReturnFrontService.RequestError<PurchaseDto>("Problemas na validacão!", validate);

            var productId = await _productRepository.GetByIdAsync(purchaseDto.ProductId);
            if (productId == null)
            {
                var product = new Product(purchaseDto.ProductName, purchaseDto.Description, purchaseDto.Price ?? 0);
                await _productRepository.CreateAsync(product);
         
            }

          
            var purchase = new Purchase(purchaseDto.ProductId, purchaseDto.ClientId);

            var data = await _purchaseRepository.CreateAsync(purchase);
            purchaseDto.Id = data.Id;
            
            return ReturnFrontService.Ok<PurchaseDto>(purchaseDto);
        }

        public async Task<ReturnFrontService<ICollection<PurchaseDto>>> GetAllPurchasesAsync()
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            return ReturnFrontService.Ok(_mapper.Map<ICollection<PurchaseDto>>(purchases));
        }

        public async Task<ReturnFrontService<ICollection<PurchaseDto>>> GetPurchaseByClientIdAsync(int clientId)
        {
            if (clientId <= 0)
                return ReturnFrontService.Fail<ICollection<PurchaseDto>>("ClientId inválido!");

            var purchases = await _purchaseRepository.GetByClientIdAsync(clientId);

            if (purchases == null || !purchases.Any())
                return ReturnFrontService.Fail<ICollection<PurchaseDto>>("Nenhuma compra encontrada para este cliente.");

           
            var purchasesDto = _mapper.Map<ICollection<PurchaseDto>>(purchases);

            return ReturnFrontService.Ok<ICollection<PurchaseDto>>(purchasesDto);
        }
    }
}
