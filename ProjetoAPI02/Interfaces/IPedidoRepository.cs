using ProjetoAPI02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Interfaces
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
        void FinalizarPedido(Pedido pedido, List<ItemPedido> itensPedido);
        List<Pedido> ConsultarPorDatas(DateTime dataMin, DateTime dataMax);
        List<Pedido> ConsultarPorCliente(Guid idCliente);

    }
}

