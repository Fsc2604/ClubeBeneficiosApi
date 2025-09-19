using ClubeBeneficiosApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Application.Interfaces
{
    public interface IClientService
    {

     
        Task<ReturnFrontService<ClientDto>> CreateAsync(ClientDto clientDTO);

        Task<ReturnFrontService<ICollection<ClientDto>>> GetAllClientsAsync();

        Task<ReturnFrontService<ClientDto>> GetByIdAsync(int clientId);

    }
}
