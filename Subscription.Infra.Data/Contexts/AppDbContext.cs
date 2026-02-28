using Microsoft.EntityFrameworkCore;
using Subscription.Infra.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Infra.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        //Método construtor
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) //Passando as configurações para a classe base (DbContext)
        {
            
        }

        //Sobrescrever um método para configurar os mapeamentos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new PlanoConfiguration());
            modelBuilder.ApplyConfiguration(new AssinaturaConfiguration());
        }
    }
}
