using ClubeBeneficiosAPi.Domain.ClubeBeneficiosAPi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Application.DTOs
{
    public class UserPermissionDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UserRole Role { get; set; }
    }
}
