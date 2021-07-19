﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoAPI02.Contexts;

namespace ProjetoAPI02.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoAPI02.Entities.Cliente", b =>
                {
                    b.Property<Guid>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDCLIENTE")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("EMAIL")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("SENHA")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdCliente");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("CLIENTE");
                });

            modelBuilder.Entity("ProjetoAPI02.Entities.Endereco", b =>
                {
                    b.Property<Guid>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDENDERECO")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnName("BAIRRO")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnName("CEP")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnName("CIDADE")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnName("COMPLEMENTO")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnName("ESTADO")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<Guid>("IdCliente")
                        .HasColumnName("IDCLIENTE")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnName("LOGRADOURO")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("NUMERO")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("IdEndereco");

                    b.HasIndex("IdCliente");

                    b.ToTable("ENDERECO");
                });

            modelBuilder.Entity("ProjetoAPI02.Entities.ItemPedido", b =>
                {
                    b.Property<Guid>("IdItemPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDITEMPEDIDO")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPedido")
                        .HasColumnName("IDPEDIDO")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProduto")
                        .HasColumnName("IDPRODUTO")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantidadeItens")
                        .HasColumnName("QUANTIDADEITENS")
                        .HasColumnType("int");

                    b.HasKey("IdItemPedido");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdProduto");

                    b.ToTable("ITEMPEDIDO");
                });

            modelBuilder.Entity("ProjetoAPI02.Entities.Pedido", b =>
                {
                    b.Property<Guid>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDPEDIDO")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnName("DATAPEDIDO")
                        .HasColumnType("date");

                    b.Property<Guid>("IdCliente")
                        .HasColumnName("IDCLIENTE")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdEndereco")
                        .HasColumnName("IDENDERECO")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnName("VALOR")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEndereco");

                    b.ToTable("PEDIDO");
                });

            modelBuilder.Entity("ProjetoAPI02.Entities.Produto", b =>
                {
                    b.Property<Guid>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDPRODUTO")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnName("FOTO")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<decimal>("Preco")
                        .HasColumnName("PRECO")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("QUANTIDADE")
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("IdProduto");

                    b.ToTable("PRODUTO");
                });

            modelBuilder.Entity("ProjetoAPI02.Entities.Endereco", b =>
                {
                    b.HasOne("ProjetoAPI02.Entities.Cliente", "Cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoAPI02.Entities.ItemPedido", b =>
                {
                    b.HasOne("ProjetoAPI02.Entities.Pedido", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoAPI02.Entities.Produto", "Produto")
                        .WithMany("ItensPedido")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoAPI02.Entities.Pedido", b =>
                {
                    b.HasOne("ProjetoAPI02.Entities.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoAPI02.Entities.Endereco", "EnderecoEntrega")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdEndereco");
                });
#pragma warning restore 612, 618
        }
    }
}
