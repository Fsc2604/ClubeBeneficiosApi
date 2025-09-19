using ClubeBeneficiosAPi.Domain.ClubeBeneficiosAPi.Domain.Enums;
using ClubeBeneficiosAPi.Domain.Entities;
using ClubeBeneficiosAPi.Domain.ValidationsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClubeBeneficiosAPI.Test.Domain.Entities
{
    public class UserPermissionTests
    {
        [Fact(DisplayName = "Não deve criar UserPermission sem Email")]
        public void NaoDeveCriarUserPermissionSemEmail()
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                 new UserPermission(null, "123", UserRole.Admin));

            Assert.Equal("Email deve ser informado", ex.Message);
        }

        [Fact(DisplayName = "Deve definir hash de senha corretamente")]
        public void DeveDefinirHashDeSenha()
        {
            var userPermission = new UserPermission("teste@teste.com", "123", UserRole.Admin);
            userPermission.SetPasswordHash(BCrypt.Net.BCrypt.HashPassword("123"));

            Assert.True(BCrypt.Net.BCrypt.Verify("123", userPermission.PasswordHash));
        }


        [Fact(DisplayName = "Deve definir hash de senha corretamente")]
        public void NaoDeveCriarSemRole()
        {
            var userPermission = new UserPermission("teste@teste.com", "123", UserRole.None);
            userPermission.SetPasswordHash(BCrypt.Net.BCrypt.HashPassword("123"));

            Assert.True(BCrypt.Net.BCrypt.Verify("123", userPermission.PasswordHash));
        }
    }
}
