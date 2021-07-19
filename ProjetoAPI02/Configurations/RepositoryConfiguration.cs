using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoAPI02.Contexts;
using ProjetoAPI02.Interfaces;
using ProjetoAPI02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Configurations
{
    public class RepositoryConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration Configuration) 
        {
            #region Repositórios

            //obtendo a string de conexão do banco de dados..
            var connectionstring = Configuration.GetConnectionString("BDProjetoAPI02");

            //passar a connectionstring para a classe SqlServerContext criada para o EF
            services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(connectionstring));

            //mapear cada interface / classe do repositorio
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            #endregion
        }

    }
}
