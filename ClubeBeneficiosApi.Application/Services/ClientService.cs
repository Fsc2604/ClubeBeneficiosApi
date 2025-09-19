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
    public class ClientService : IClientService
     {

        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {

            _clientRepository = clientRepository;
            _mapper = mapper;

            
        }

        public async Task<ReturnFrontService<ClientDto>> CreateAsync(ClientDto clientDTO)
        {
            if (clientDTO == null)

                return ReturnFrontService.Fail<ClientDto>("Objeto Deve ser  informado");
            
           var result = new ClientDtoValidator().Validate(clientDTO);
            if(!result.IsValid)
             return ReturnFrontService.RequestError<ClientDto>("Problemas de validacao", result);

            //Transforma Dto em entidade
            var client = _mapper.Map<Client>(clientDTO);
            var data = await _clientRepository.CreateAsync(client);

            //Retorna Dto para o Front
            return ReturnFrontService.Ok<ClientDto>(_mapper.Map<ClientDto>(data));
        }

       

        public async Task<ReturnFrontService<ICollection<ClientDto>>> GetAllClientsAsync()
        {
          var clients = await _clientRepository.GetClientsAsync();

            return ReturnFrontService.Ok<ICollection<ClientDto>>(_mapper.Map<ICollection<ClientDto>>(clients));
        }

        public async Task<ReturnFrontService<ClientDto>> GetByIdAsync(int clientId)
        {
            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null)
                return ReturnFrontService.Fail<ClientDto>("Cliente  não encontrado!");

            return ReturnFrontService.Ok(_mapper.Map<ClientDto>(client));
        }
    }
}
