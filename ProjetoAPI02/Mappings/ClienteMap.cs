using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAPI02.Entities;

namespace ProjetoAPI02.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //nome da tabela
            builder.ToTable("CLIENTE");

            //chave primária
            builder.HasKey(c => c.IdCliente);

            //demais campos
            builder.Property(c => c.IdCliente)
                .HasColumnName("IDCLIENTE")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(50)
                .IsRequired();

            //Mapeamento de índices
            //Definindo campos únicos (UNIQUE) na tabela

            //CPF como campo UNIQUE
            builder.HasIndex(c => c.Cpf)
                .IsUnique(true);

            //EMAIL como campo UNIQUE
            builder.HasIndex(c => c.Email)
                .IsUnique(true);

        }
    }
}
