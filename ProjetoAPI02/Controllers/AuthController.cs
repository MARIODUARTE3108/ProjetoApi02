using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI02.Entities;
using ProjetoAPI02.Interfaces;
using ProjetoAPI02.Models;
using ProjetoAPI02.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(AuthPostModel model,
            [FromServices] IClienteRepository clienteRepository,
            [FromServices] IEnderecoRepository enderecoRepository,
            [FromServices] TokenService tokenService,
            [FromServices] IMapper mapper)
        {
            try
            {
                //buscar o cliente na base atraves do email e da senha..
                var cliente = clienteRepository.ObterPorEmailESenha(model.Email, model.Senha);

                //verificar se o cliente foi encontrado..
                if (cliente != null)
                {
                    //consultar os endereços do cliente..
                    var enderecos = enderecoRepository.ConsultarPorCliente(cliente.IdCliente);

                    //utilizando o AutoMapper para transferir os dados para os modelos
                    var clienteModel = mapper.Map<ClienteGetModel>(cliente);
                    clienteModel.Enderecos = mapper.Map<List<EnderecoGetModel>>(enderecos);

                    //tempo de expiração do token em horas
                    var tempoExpiracaoToken = 24; //1 dia

                    //objeto para retornar os dados de resposta
                    //de sucesso do método..
                    var result = new
                    {
                        Mensagem = "Autenticação realizada com sucesso.",
                        AccessToken = tokenService.GenerateToken(cliente.Email, tempoExpiracaoToken),
                        ExpiraEm = DateTime.Now.AddHours(tempoExpiracaoToken),
                        Cliente = clienteModel
                    };

                    return Ok(result);
                }
                else
                {
                    //UNAUTHORIZED (HTTP 401)
                    return Unauthorized("Acesso negado.");
                }
            }
            catch (Exception e)
            {
                //INTERNAL SERVER ERROR (HTTP 500)
                return StatusCode(500, e.Message);
            }
        }
    }
}



