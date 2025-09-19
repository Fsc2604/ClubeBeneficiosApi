using ClubeBeneficiosApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Application.Interfaces
{
    public interface IUserPermissionService
    {
        Task<ReturnFrontService<dynamic>> GenerateTokenAsync(UserPermissionDto userPermissionDto);
    }
}
