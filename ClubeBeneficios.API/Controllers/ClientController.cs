using ClubeBeneficiosApi.Application.DTOs;
using ClubeBeneficiosApi.Application.Interfaces;
using ClubeBeneficiosAPi.Domain.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ClubeBeneficios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseControllers
    {
        private readonly IClientService _clientService;
        private readonly ICurrentUserInfo _currentUserInfo;
        private List<string> _permissionNedeed = new List<string>() { "Admin" };


        public ClientController(IClientService clientService, ICurrentUserInfo currentUserInfo)
        {
            _clientService = clientService;
            _currentUserInfo = currentUserInfo;
            _permissionNedeed = _currentUserInfo?.Permissions?.Split(",")?.ToList() ?? new List<string>();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ClientDto clientDto)
        {
              _permissionNedeed.Add("CadastraPessoa");
             if(!ValidPermission(_permissionNedeed, _permissionNedeed))
              return Forbidden();

            var result = await _clientService.CreateAsync(clientDto);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientsAsync()
        {
            _permissionNedeed.Add("BuscaPessoa");
            if (!ValidPermission( _permissionNedeed, _permissionNedeed))
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
            _permissionNedeed.Add("BuscaPessoa");
            if (!ValidPermission(_permissionNedeed, _permissionNedeed))
                return Forbidden();

            var result = await _clientService.GetByIdAsync(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
