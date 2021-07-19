using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Models
{
    public class PedidoGetModel
    {
        public Guid IdPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal Valor { get; set; }

        public ClienteGetModel Cliente { get; set; }
        public EnderecoGetModel EnderecoEntrega { get; set; }

        public List<ItemPedidoGetModel> ItensPedido { get; set; }
    }
}
