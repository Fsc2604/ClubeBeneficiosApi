using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeBeneficiosAPi.Domain.Entities;

namespace ClubeBeneficiosApi.Infra.Data.Maps
{
  
     public class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            //Nome da tabela no banco
            builder.ToTable("permissaousuario");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Colulnas da Tabela
            builder.Property(x => x.Id)
                   .HasColumnName("idpermissaousuario")
                   .UseIdentityColumn();

            builder.Property(x => x.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(150);

            builder.Property(x => x.PasswordHash)
                     .HasColumnName("password_hash")
                     .IsRequired();

            builder.Property(x => x.Role)
                     .HasColumnName("tipo_permissao")
                     .HasConversion<int>() 
                     .IsRequired();

            builder.HasOne<Client>()
       .WithOne(c => c.Permission)
       .HasForeignKey<UserPermission>(up => up.ClientId);
        }
    }
}
