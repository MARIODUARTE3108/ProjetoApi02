using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAPI02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("ENDERECO");

            builder.HasKey(e => e.IdEndereco);

            builder.Property(e => e.IdEndereco)
                .HasColumnName("IDENDERECO");

            builder.Property(e => e.Logradouro)
                .HasColumnName("LOGRADOURO")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.Numero)
                .HasColumnName("NUMERO")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnName("COMPLEMENTO")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(e => e.Bairro)
                .HasColumnName("BAIRRO")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Cidade)
                .HasColumnName("CIDADE")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Estado)
                .HasColumnName("ESTADO")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(e => e.Cep)
                .HasColumnName("CEP")
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(e => e.IdCliente)
                .HasColumnName("IDCLIENTE")
                .IsRequired();

            //Mapeamento de relacionamentos
            //Endereco PERTENCE a 1 Cliente
            //Cliente POSSUI muitos Enderecos
            builder.HasOne(e => e.Cliente) //Endereco TEM 1 Cliente
                .WithMany(c => c.Enderecos) //Cliente TEM MUITOS Enderecos
                .HasForeignKey(e => e.IdCliente); //Chave estrangeira
        }
    }
}
