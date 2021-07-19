using ProjetoAPI02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Interfaces
{
    public interface IItemPedidoRepository : IBaseRepository<ItemPedido>
    {
        List<ItemPedido> ConsultarPorPedido(Guid idPedido);
    }
}
