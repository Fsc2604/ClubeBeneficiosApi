using ClubeBeneficiosAPi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Infra.Data.Maps
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            //Nome da tabela no banco
            builder.ToTable("compra");

            // Chave primária
            builder.HasKey(x => x.Id);

            //Colunas da tabela

            builder.Property(x => x.ClientId)
          .HasColumnName("idcompra")
          .UseIdentityColumn();

            builder.Property(x => x.Id)
            .HasColumnName("idpessoa");

            builder.Property(x => x.ProductId)
            .HasColumnName("idproduto");

       

            // Mapeamento/Relacionamento chave primária com chave estrangeira
            // Uma compra só pode ter um cliente mas uma cliente pode ter várias compras
            // 1 pra N
            builder.HasOne(x => x.Client)
                .WithMany(p => p.Purchases);

            builder.HasOne(x => x.Product)
               .WithMany(p => p.Purchases);
        }


    }
}
