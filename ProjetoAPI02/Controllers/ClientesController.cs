using AutoMapper;
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
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClientePostModel model,
            [FromServices] IClienteRepository clienteRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                //pesquisar o cliente no banco de dados pelo email..
                //verificar se o cliente foi encontrado
                if (clienteRepository.ObterPorEmail(model.Email) != null)
                {
                    return UnprocessableEntity("O email informado já encontra-se cadastrado.");
                }
                else
                {
                    var cliente = mapper.Map<Cliente>(model);
                    clienteRepository.Inserir(cliente);

                    return Ok("Cliente cadastrado com sucesso.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ClientePutModel model,
            [FromServices] IClienteRepository clienteRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                if (clienteRepository.ObterPorId(model.IdCliente) == null)
                {
                    return UnprocessableEntity("Cliente não encontrado.");
                }

                var cliente = mapper.Map<Cliente>(model);

                clienteRepository.Alterar(cliente);
                return Ok("Cliente atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idCliente}")]
        public IActionResult Delete(Guid idCliente,
            [FromServices] IClienteRepository clienteRepository)
        {
            try
            {
                var cliente = clienteRepository.ObterPorId(idCliente);

                if (cliente == null)
                {
                    return UnprocessableEntity("Cliente não encontrado.");
                }

                //excluindo o cliente
                clienteRepository.Excluir(cliente);
                return Ok("Cliente excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] IClienteRepository clienteRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var clientes = clienteRepository.Consultar();
                var lista = mapper.Map<List<ClienteGetModel>>(clientes);

                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idCliente}")]
        public IActionResult GetById(Guid idCliente,
            [FromServices] IClienteRepository clienteRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var cliente = clienteRepository.ObterPorId(idCliente);

                if (cliente == null)
                {
                    return NoContent();
                }

                var model = mapper.Map<ClienteGetModel>(cliente);
                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
