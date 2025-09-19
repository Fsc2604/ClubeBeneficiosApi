using ClubeBeneficiosAPi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosAPi.Domain.Repositories
{
    public interface IUserPermissionRepository
    {
        Task<UserPermission?> GetUserByEmailAsync(string email);

        Task<UserPermission?> CreateAsync(UserPermission userPermission);
    }
}
