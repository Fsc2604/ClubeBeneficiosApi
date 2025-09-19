using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosAPi.Domain
{
    namespace ClubeBeneficiosAPi.Domain.Enums
    {
        public enum UserRole
        {   
            None, // Usado só para testes unitários
            Admin = 1,
            Client = 2
        }
    }
}
