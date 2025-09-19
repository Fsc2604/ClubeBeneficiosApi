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
    public class ClientTest
    {
        [Fact(DisplayName = "Não deve criar Client sem Email")]
        public void CriaClient_Client_NaoCriaClientSemEmail()
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                     new Client( clientName: "Test", email: null, password: "1234456"));

            Assert.Equal("Email deve ser informado", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar Client sem Password")]
        public void CriaClient_Client_NaoCriaClientSemPassword()
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                     new Client(clientName: "Test", email: "123456@gmsil.com",  null));

            Assert.Equal("Email deve ser informado", ex.Message);
        }



        [Fact(DisplayName = "Deve criar Client")]
        public void CriaClient_Client_DeveCriarClient()
        {
            var client = new Client( "Test" , "Test", "1234456");
            Assert.NotNull(client);
        }

    }
}
