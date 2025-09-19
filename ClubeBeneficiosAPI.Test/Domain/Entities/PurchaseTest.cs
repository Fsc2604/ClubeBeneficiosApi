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
    public class PurchaseTest
    {
        [Fact(DisplayName = "Não deve criar compra sem o id produto")]
        public void CriaCompra_Purchase_NaoCriaCompraSemProductId()
        {
            var ex = Assert.Throws<DomainValidationException>(() => new Purchase(1, 9));
            Assert.Equal("Id Produto deve ser informado", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar compra sem o id cliente")]
        public void CriaCompra_Purchase_NaoCriaCompraSemClientId()
        {
            var ex = Assert.Throws<DomainValidationException>(() => new Purchase(0, 1));
            Assert.Equal("Id do Cliente deve ser informado", ex.Message);
        }


        [Fact(DisplayName = "Deve criar compra com Id")]
        public void CriaCompra_Purchase_CriaCompraComId()
        {
            var purchase = new Purchase( 2, 1);
            Assert.NotNull(purchase);
        }

     
    }
}
