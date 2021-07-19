using Microsoft.EntityFrameworkCore;
using ProjetoAPI02.Entities;
using ProjetoAPI02.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Contexts
{
    //REGRA 1) A classe deverá HERDAR DbContext
    public class SqlServerContext : DbContext
    {
        //REGRA 2) Criar um método construtor para receber
        //os parametros de conexão do banco, como por exemplo,
        //a connectionstring
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options) //passando os parametros para a superclasse
        {

        }

        //REGRA 3) Adicionando cada classe de entidade do projeto
        //como uma propriedade do tipo DbSet (CRUD)
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        //REGRA 4) Sobrescrever o método OnModelCreating
        //utilizado para registrar cada classe de mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionando cada classe de mapeamento..
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ItemPedidoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
        }
    }
}
