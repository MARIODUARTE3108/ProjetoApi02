using Microsoft.EntityFrameworkCore;
using ProjetoAPI02.Contexts;
using ProjetoAPI02.Entities;
using ProjetoAPI02.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly SqlServerContext _context;

        public PedidoRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public List<Pedido> ConsultarPorDatas(DateTime dataMin, DateTime dataMax)
        {
            return _context.Pedido
                    .Where(p => p.DataPedido >= dataMin
                             && p.DataPedido <= dataMax)
                    .ToList();
        }

        public void FinalizarPedido(Pedido pedido, List<ItemPedido> itensPedido)
        {
            //abrir uma transação no banco de dados
            var transaction = _context.Database.BeginTransaction();

            try
            {
                //primeiro, iremos gravar no banco de dados o pedido..
                _context.Pedido.Add(pedido);
                _context.SaveChanges();

                //segundo, iremos gravar os itens do pedido..
                foreach (var item in itensPedido)
                {
                    //cada item de pedido deve estar associado ao pedido..
                    //este vinculo deve ser feito por meio de foreign key
                    item.IdPedido = pedido.IdPedido;

                    //salvar o item do pedido no banco de dados
                    _context.ItemPedido.Add(item);
                    _context.SaveChanges();
                }

                //faz o COMMIT (confirma) da transação
                transaction.Commit();
            }
            catch (Exception e)
            {
                //desfazer as operações realizadas na transação
                transaction.Rollback();

                //retornar um erro para a API..
                throw new Exception("Erro ao cadastrar o Pedido: " + e.Message);
            }
        }

        public List<Pedido> ConsultarPorCliente(Guid idCliente)
        {
            return _context.Pedido
                .Include(p => p.Cliente)
                .Include(p => p.EnderecoEntrega)
                .Where(p => p.IdCliente.Equals(idCliente))
                .OrderByDescending(p => p.DataPedido)
                .ToList();
        }
    }
}


