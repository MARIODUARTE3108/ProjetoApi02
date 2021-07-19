using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAPI02.Entities;

namespace ProjetoAPI02.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            //nome da tabela
            builder.ToTable("PEDIDO");

            //chave primária
            builder.HasKey(p => p.IdPedido);

            //demais campos
            builder.Property(p => p.IdPedido)
                .HasColumnName("IDPEDIDO")
                .IsRequired();

            builder.Property(p => p.DataPedido)
                .HasColumnName("DATAPEDIDO")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnName("VALOR")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.IdCliente)
                .HasColumnName("IDCLIENTE")
                .IsRequired();

            builder.Property(p => p.IdEndereco)
                .HasColumnName("IDENDERECO");

            //Mapeamento de relacionamento
            //Cardinalidade: 1 para muitos
            builder.HasOne(p => p.Cliente) //Pedido TEM-1 Cliente
                .WithMany(c => c.Pedidos) //Cliente TEM-MUITOS Pedidos
                .HasForeignKey(p => p.IdCliente); //Chave Estrangeira

            //Mapeamento de relacionamento
            //Cardinalidade: 1 para muitos
            builder.HasOne(p => p.EnderecoEntrega) //Pedido TEM-1 Endereco
                .WithMany(e => e.Pedidos) //Endereco TEM MUITOS Pedidos
                .HasForeignKey(p => p.IdEndereco); //Chave estrangeira

        }
    }
}
