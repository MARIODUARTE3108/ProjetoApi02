using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAPI02.Entities;

namespace ProjetoAPI02.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //nome da tabela
            builder.ToTable("PRODUTO");

            //chave primária
            builder.HasKey(p => p.IdProduto);

            //demais campos
            builder.Property(p => p.IdProduto)
                .HasColumnName("IDPRODUTO")
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("PRECO")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE")
                .HasDefaultValue(0);

            builder.Property(p => p.Foto)
                .HasColumnName("FOTO")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
