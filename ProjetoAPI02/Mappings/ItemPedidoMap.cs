using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAPI02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Mappings
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            //nome da tabela no banco de dados
            builder.ToTable("ITEMPEDIDO");

            //chave primária
            builder.HasKey(i => i.IdItemPedido);

            //campos da tabela
            builder.Property(i => i.IdItemPedido)
                .HasColumnName("IDITEMPEDIDO")
                .IsRequired();

            builder.Property(i => i.IdPedido)
                .HasColumnName("IDPEDIDO")
                .IsRequired();

            builder.Property(i => i.IdProduto)
                .HasColumnName("IDPRODUTO")
                .IsRequired();

            builder.Property(i => i.QuantidadeItens)
                .HasColumnName("QUANTIDADEITENS")
                .IsRequired();

            //Mapeamento de relacionamento
            builder.HasOne(i => i.Pedido) //Item pertence a 1 pedido
                .WithMany(p => p.ItensPedido) //1 pedido por ter muitos itens
                .HasForeignKey(i => i.IdPedido); //chave estrangeira

            //Mapeamento de relacionamento
            builder.HasOne(i => i.Produto) //Item possui 1 produto
                .WithMany(p => p.ItensPedido) //produto pode ter muitos itens
                .HasForeignKey(i => i.IdProduto); //chave estrangeira
        }
    }
}
