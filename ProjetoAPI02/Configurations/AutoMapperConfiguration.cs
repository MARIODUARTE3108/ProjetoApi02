using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjetoAPI02.Entities;
using ProjetoAPI02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        //método construtor -> ctor + 2x[tab]
        public AutoMapperConfiguration()
        {
            #region Requests (POST, PUT)

            CreateMap<ClientePostModel, Cliente>()
                .AfterMap((src, dest) =>
                {
                    dest.IdCliente = Guid.NewGuid();
                });

            CreateMap<ClientePutModel, Cliente>();

            CreateMap<EnderecoPostModel, Endereco>()
                .AfterMap((src, dest) =>
                {
                    dest.IdEndereco = Guid.NewGuid();
                });

            CreateMap<EnderecoPutModel, Endereco>();

            CreateMap<ProdutoPostModel, Produto>()
                .AfterMap((src, dest) =>
                {
                    dest.IdProduto = Guid.NewGuid();
                });

            CreateMap<ProdutoPutModel, Produto>();

            CreateMap<PedidoPostModel, Pedido>()
                .AfterMap((src, dest) =>
                {
                    dest.IdPedido = Guid.NewGuid();
                });

            CreateMap<ItemPedidoPostModel, ItemPedido>()
                .AfterMap((src, dest) =>
                {
                    dest.IdItemPedido = Guid.NewGuid();
                });

            #endregion

            #region Responses (GET)

            CreateMap<Cliente, ClienteGetModel>();
            CreateMap<Endereco, EnderecoGetModel>();
            CreateMap<Produto, ProdutoGetModel>();
            CreateMap<Pedido, PedidoGetModel>();
            CreateMap<ItemPedido, ItemPedidoGetModel>();

            #endregion
        }

        //método para adicionar o automapper no container da classe Startup
        public static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}



