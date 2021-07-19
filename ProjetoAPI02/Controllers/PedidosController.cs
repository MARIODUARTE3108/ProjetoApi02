using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI02.Entities;
using ProjetoAPI02.Interfaces;
using ProjetoAPI02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(PedidoPostModel model,
           [FromServices] IPedidoRepository pedidoRepository,
           [FromServices] IClienteRepository clienteRepository,
           [FromServices] IEnderecoRepository enderecoRepository,
           [FromServices] IMapper mapper)
        {
            try
            {
                var pedido = mapper.Map<Pedido>(model);

                //capturar o cliente autenticado atraves do email
                var cliente = clienteRepository.ObterPorEmail(User.Identity.Name);
                pedido.IdCliente = cliente.IdCliente;

                //capturar todos os endereços cadastrados do cliente
                var enderecos = enderecoRepository.ConsultarPorCliente(cliente.IdCliente);
                //verificando se o endereço de entrega não é um dos endereços do cliente..
                if (enderecos.FirstOrDefault(e => e.IdEndereco.Equals(model.IdEnderecoEntrega)) == null)
                {
                    return UnprocessableEntity("O Endereço de entrega é inválido. Verifique os endereços do cliente.");
                }

                //associar o endereço de entrega do pedido
                pedido.IdEndereco = model.IdEnderecoEntrega;

                //capturar os dados dos itens do pedido..
                var itensPedido = mapper.Map<List<ItemPedido>>(model.ItensPedido);

                //gravar o pedido..
                pedidoRepository.FinalizarPedido(pedido, itensPedido);

                return Ok("Pedido realizado com sucesso.");
            }
            catch (Exception e)
            {
                //HTTP 500 - INTERNAL SERVER ERROR
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(
            [FromServices] IPedidoRepository pedidoRepository,
            [FromServices] IItemPedidoRepository itemPedidoRepository,
            [FromServices] IClienteRepository clienteRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                //buscar o cliente autenticado
                var cliente = clienteRepository.ObterPorEmail(User.Identity.Name);

                //buscar os pedidos do cliente
                var pedidos = pedidoRepository.ConsultarPorCliente(cliente.IdCliente);
                var model = mapper.Map<List<PedidoGetModel>>(pedidos);

                //percorrendo os pedidos
                foreach (var pedido in model)
                {
                    //buscando os itens do pedido
                    var itensPedido = itemPedidoRepository.ConsultarPorPedido(pedido.IdPedido);
                    pedido.ItensPedido = mapper.Map<List<ItemPedidoGetModel>>(itensPedido);
                }

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

