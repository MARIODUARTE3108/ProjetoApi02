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
    public class EnderecosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(EnderecoPostModel model,
             [FromServices] IEnderecoRepository enderecoRepository,
             [FromServices] IClienteRepository clienteRepository,
             [FromServices] IMapper mapper)
        {
            try
            {
                var endereco = mapper.Map<Endereco>(model);

                //buscar os dados do cliente autenticado..
                var cliente = clienteRepository.ObterPorEmail(User.Identity.Name);
                endereco.IdCliente = cliente.IdCliente; //relacionamento (foreign key)

                //cadastrando o endereço na base de dados
                enderecoRepository.Inserir(endereco);

                return Ok("Endereço cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(EnderecoPutModel model,
            [FromServices] IEnderecoRepository enderecoRepository,
            [FromServices] IClienteRepository clienteRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var endereco = mapper.Map<Endereco>(model);

                //buscar os dados do cliente autenticado..
                var cliente = clienteRepository.ObterPorEmail(User.Identity.Name);
                endereco.IdCliente = cliente.IdCliente;

                //atualizando os dados
                enderecoRepository.Alterar(endereco);

                return Ok("Endereço atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id,
            [FromServices] IEnderecoRepository enderecoRepository)
        {
            try
            {
                var endereco = enderecoRepository.ObterPorId(id);
                enderecoRepository.Excluir(endereco);

                return Ok("Endereço excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] IEnderecoRepository enderecoRepository,
            [FromServices] IClienteRepository clienteRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                //obtendo o cliente autenticado no serviço
                var cliente = clienteRepository.ObterPorEmail(User.Identity.Name);

                //consultar todos os endereços deste cliente
                var enderecos = enderecoRepository.ConsultarPorCliente(cliente.IdCliente);

                var model = mapper.Map<List<EnderecoGetModel>>(enderecos);
                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}


