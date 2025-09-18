using ClubeBeneficiosApi.Infra.Data.Context;
using ClubeBeneficiosAPi.Domain.Entities;
using ClubeBeneficiosAPi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Infra.Data.Repositories
{
    public class UserPermissionRepository : IUserPermissionRepository
    {
        private readonly ConnectionDbContext _ConnectionDbContext;
        public UserPermissionRepository(ConnectionDbContext connectionDbContext) { 
        
            _ConnectionDbContext = connectionDbContext;
        
        }
        public async Task<UserPermission?> GetUserByEmailAsync(string email)
        {
            var getUser = _ConnectionDbContext.UserPermissions.FirstOrDefaultAsync(e => e.Email == email);

            return await getUser;
        }
    }
}
