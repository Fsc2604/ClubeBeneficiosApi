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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Nome da tabela no banco
            builder.ToTable("produto");

            // Chave primária
            builder.HasKey(x => x.Id);

            //Colunas da tabela

            builder.Property(x => x.Id)
          .HasColumnName("idcliente")
          .UseIdentityColumn();

            builder.Property(x => x.ProductName)
            .HasColumnName("name");

            builder.Property(x => x.Description)
            .HasColumnName("email");

            builder.Property(x => x.Price)
            .HasColumnName("senha");

            // Mapeamento/Relacionamento chave primária com chave estrangeira
            // Uma produto pode estar em várias  compras mas uma compra pode ter somente um respectivo produto 
            // 1 pra N
            builder.HasMany(c => c.Purchases)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);

        }

    }
}
