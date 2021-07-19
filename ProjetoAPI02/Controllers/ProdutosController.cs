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
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ProdutoPostModel model,
             [FromServices] IProdutoRepository produtoRepository,
             [FromServices] IMapper mapper)
        {
            try
            {
                var produto = mapper.Map<Produto>(model);
                produtoRepository.Inserir(produto);

                return Ok("Produto cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                //retornar erro (HTTP 500 - INTERNAL SERVER ERROR)
                return StatusCode(500, e.Message);
            }
        }


        [HttpPut]
        public IActionResult Put(ProdutoPutModel model,
            [FromServices] IProdutoRepository produtoRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                //verificando se o produto não existe na base de dados
                if (produtoRepository.ObterPorId(model.IdProduto) == null)
                {
                    return UnprocessableEntity("Produto não encontrado.");
                }

                var produto = mapper.Map<Produto>(model);
                produtoRepository.Alterar(produto);

                return Ok("Produto atualizado com sucesso.");
            }
            catch (Exception e)
            {
                //RETORNAR ERRO HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idProduto}")]
        public IActionResult Delete(Guid idProduto,
            [FromServices] IProdutoRepository produtoRepository)
        {
            try
            {
                var produto = produtoRepository.ObterPorId(idProduto);

                //verificando se o produto não existe na base de dados
                if (produto == null)
                {
                    return UnprocessableEntity("Produto não encontrado.");
                }

                produtoRepository.Excluir(produto);
                return Ok("Produto excluído com sucesso.");
            }
            catch (Exception e)
            {
                //RETORNAR ERRO HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] IProdutoRepository produtoRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var produtos = produtoRepository.Consultar();

                var lista = mapper.Map<List<ProdutoGetModel>>(produtos);
                return Ok(lista);
            }
            catch (Exception e)
            {
                //RETORNAR ERRO HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idProduto}")]
        public IActionResult GetById(Guid idProduto,
            [FromServices] IProdutoRepository produtoRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                //buscando 1 produto no banco de dados atraves do ID..
                var produto = produtoRepository.ObterPorId(idProduto);

                if (produto == null)
                {
                    return NoContent(); //204 (VAZIO)
                }

                var model = mapper.Map<ProdutoGetModel>(produto);
                return Ok(model);
            }
            catch (Exception e)
            {
                //RETORNAR ERRO HTTP 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, e.Message);
            }
        }
    }
}