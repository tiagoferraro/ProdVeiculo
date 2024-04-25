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
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Codigo);
            builder.Property(x => x.Descricao).HasMaxLength(200).IsRequired();
            builder.Property(x => x.DataFabricacao).HasColumnType("smalldatetime");
            builder.Property(x => x.DataValidade).HasColumnType("smalldatetime");
            builder.Property(x => x.DataCadastro).HasColumnType("smalldatetime");
            builder.HasOne(x => x.Fornecedor)
                 .WithMany(x => x.Produtos)
                 .HasForeignKey(x => x.FornecedorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
