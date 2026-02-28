using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Subscription.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subscription.Infra.Data.Configurations
{
    public class AssinaturaConfiguration : IEntityTypeConfiguration<Assinatura>
    {
        public void Configure(EntityTypeBuilder<Assinatura> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Valor).HasPrecision(10, 2);

            builder.Property(a => a.Status).HasConversion<string>();

            builder.HasOne(a => a.Cliente) //Assinatura TEM 1 Cliente
                .WithMany(c => c.Assinaturas) //Cliente TEM MUITAS Assinaturas
                .HasForeignKey(a => a.ClienteId) //Chave estrangeira para Cliente
                .OnDelete(DeleteBehavior.Restrict); //Não fazer deleção em cascata

            builder.HasOne(a => a.Plano) //Assinatura TEM 1 Plano
                .WithMany(p => p.Assinaturas) //Plano TEM MUITAS Assinaturas
                .HasForeignKey(a => a.PlanoId) //Chave estrangeira para Plano
                .OnDelete(DeleteBehavior.Restrict); //Não fazer deleção em cascata
        }
    }
}
