using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdVeiculo.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdVeiculo.Infra.EntitiesConfiguration
{


    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.Codigo);                
            builder.Property(x => x.Descricao).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Cnpj ).HasMaxLength(14).IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnType("smalldatetime");
            builder.HasMany(x => x.Produtos)
                   .WithOne(x => x.Fornecedor )
                   .HasForeignKey(x => x.FornecedorId).OnDelete(DeleteBehavior.NoAction); 
        }
    }
}
