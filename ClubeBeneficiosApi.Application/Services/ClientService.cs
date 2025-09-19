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
        private readonly IUserPermissionRepository _userPermissionRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper, IUserPermissionRepository userPermissionRepository)
        {

            _clientRepository = clientRepository;
            _mapper = mapper;
            _userPermissionRepository = userPermissionRepository;
        }

        public async Task<ReturnFrontService<ClientDto>> CreateAsync(ClientDto clientDto, UserPermissionDto userPermissionDto)
        {
            var clientValidator = new ClientDtoValidator().Validate(clientDto);
            if (!clientValidator.IsValid)
                return ReturnFrontService.RequestError<ClientDto>("Problemas com a validação do cliente", clientValidator);

            var userValidator = new UserPermissionDtoValidator().Validate(userPermissionDto);
            if (!userValidator.IsValid) ;

        
            var client = _mapper.Map<Client>(clientDto);


            

            var userPermission = _mapper.Map<UserPermission>(userPermissionDto);


            userPermission.SetPasswordHash(BCrypt.Net.BCrypt.HashPassword(userPermissionDto.Password));


            await _userPermissionRepository.CreateAsync(userPermission);

        
            client.Permission = userPermission;

        
            await _clientRepository.CreateAsync(client);


            var clientToDtoAgain = _mapper.Map<ClientDto>(client);

            return ReturnFrontService.Ok(clientToDtoAgain);
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

        Task<ReturnFrontService<ClientDto>> IClientService.CreateAsync(ClientDto clientDTO, UserPermissionDto userPermissionDto)
        {
            throw new NotImplementedException();
        }
    }
}
