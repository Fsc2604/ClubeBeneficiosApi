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
    public class ProductService : IProductService
    {

        private readonly IProducttRepository _productRepository;
        private readonly IMapper _mapper;

        public  ProductService(IProducttRepository producttRepository, IMapper mapper)
        {
            _productRepository = producttRepository;
            _mapper = mapper;

        }
        public async Task<ReturnFrontService<ProductDto>> CreateAsync(ProductDto productDto)
        {
            if (productDto == null)
                return ReturnFrontService.Fail<ProductDto>("Objeto deve ser informado!");

            var result = new ProductDtoValidator().Validate(productDto);
            if (!result.IsValid)
                return ReturnFrontService.RequestError<ProductDto>("Problemas na validacão!", result);

            var product = _mapper.Map<Product>(productDto);
            var data = await _productRepository.CreateAsync(product);

            return ReturnFrontService.Ok<ProductDto>(_mapper.Map<ProductDto>(data));

        }


        public async Task<ReturnFrontService<ICollection<ProductDto>>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();

            return ReturnFrontService.Ok<ICollection<ProductDto>>(_mapper.Map<ICollection<ProductDto>>(products));
        }

        public async Task<ReturnFrontService<ProductDto>> GetByIdAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                return ReturnFrontService.Fail<ProductDto>("Produto  não encontrado!");

            return ReturnFrontService.Ok(_mapper.Map<ProductDto>(product));
        }

        public async Task<ReturnFrontService<ICollection<ProductDto>>> GetProductsByFilteringAsync(decimal minPrice, decimal maxPrice)
        {
            var productsByFiltering = await _productRepository.GetProductsByPriceAsync(minPrice, maxPrice);

            return ReturnFrontService.Ok<ICollection<ProductDto>>(_mapper.Map<ICollection<ProductDto>>(productsByFiltering));
        }
    }
}
