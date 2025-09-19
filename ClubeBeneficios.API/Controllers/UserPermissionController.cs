using ClubeBeneficiosApi.Application.DTOs;
using ClubeBeneficiosApi.Application.Interfaces;
using ClubeBeneficiosApi.Application.Services;
using ClubeBeneficiosAPi.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClubeBeneficios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionController : BaseControllers
    {
        private readonly IUserPermissionService _userPermissionService;

        public UserPermissionController(IUserPermissionService userPermissionService)
        {
            _userPermissionService = userPermissionService;
        }

        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> PostAsync([FromForm] UserPermissionDto userPermissionDto)
        {
            var result = await _userPermissionService.GenerateTokenAsync(userPermissionDto);
            if (result.IsSucess)
                return Ok(result.Data);

            return BadRequest(result);
        }
    }
}
