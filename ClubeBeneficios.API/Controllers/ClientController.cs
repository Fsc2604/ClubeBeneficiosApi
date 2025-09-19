using ClubeBeneficiosApi.Application.DTOs;
using ClubeBeneficiosApi.Application.Interfaces;
using ClubeBeneficiosAPi.Domain.Authentication;
using ClubeBeneficiosAPi.Domain.ClubeBeneficiosAPi.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ClubeBeneficios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseControllers
    {
        private readonly IClientService _clientService;
        private readonly ICurrentUserInfo _currentUserInfo;
      


        public ClientController(IClientService clientService, ICurrentUserInfo currentUserInfo)
        {
            _clientService = clientService;
            _currentUserInfo = currentUserInfo;
        
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ClientDto clientDto, UserPermissionDto userPermissionDto)
        {
       

            var permissionNeeded = new List<UserRole> { UserRole.Admin, UserRole.Client };

            var userRole = _currentUserInfo.Role;

            if (!permissionNeeded.Contains(userRole))
                return Forbidden();

            var result = await _clientService.CreateAsync(clientDto, userPermissionDto);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientsAsync()
        {
            var permissionNeeded = new List<UserRole> { UserRole.Admin, UserRole.Client };

            var userRole = _currentUserInfo.Role;

            if (!permissionNeeded.Contains(userRole))
                return Forbidden();

            var result = await _clientService.GetAllClientsAsync() ;
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var permissionNeeded = new List<UserRole> { UserRole.Admin, UserRole.Client };

            var userRole = _currentUserInfo.Role;

            if (!permissionNeeded.Contains(userRole))
                return Forbidden();

            var result = await _clientService.GetByIdAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
