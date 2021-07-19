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
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        private readonly SqlServerContext _context;

        public ItemPedidoRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public List<ItemPedido> ConsultarPorPedido(Guid idPedido)
        {
            return _context.ItemPedido
                               .Include(p => p.Produto) //JOIN
                               .Where(i => i.IdPedido.Equals(idPedido))
                               .OrderByDescending(i => i.QuantidadeItens)
                               .ToList();
        }
    }
}