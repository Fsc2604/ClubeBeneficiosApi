using ClubeBeneficiosAPi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeBeneficiosApi.Infra.Data.Context
{
    public class ConnectionDbContext : DbContext
    {

        public ConnectionDbContext(DbContextOptions<ConnectionDbContext> options) : base(options) {
        
        
        }


        // Conexao com o banco
        //Criando Dbset = Tabelas
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }

        public DbSet<UserPermission> UserPermissions { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConnectionDbContext).Assembly);
        }
    }
}
