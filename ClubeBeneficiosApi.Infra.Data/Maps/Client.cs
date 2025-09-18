using ClubeBeneficiosAPi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Infra.Data.Maps
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {

        public void Configure(EntityTypeBuilder<Client> builder)
        {
            //Nome da tabela no banco
            builder.ToTable("cliente");

            // Chave primária
            builder.HasKey(x => x.Id);

            //Colunas da tabela

            builder.Property(x => x.Id)
          .HasColumnName("idcliente")
          .UseIdentityColumn();

            builder.Property(x => x.Name)
            .HasColumnName("name");

            builder.Property(x => x.Email)
            .HasColumnName("email");

            builder.Property(x => x.Password)
            .HasColumnName("senha");

            // Mapeamento/Relacionamento chave primária com chave estrangeira
            // Um cliente pode ter uma lista de compras mas uma compra é referentea a um cliente
            // N pra 1
            builder.HasMany(c => c.Purchases)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId);

        }
    }
}
