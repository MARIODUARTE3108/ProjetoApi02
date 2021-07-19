using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Models
{
    public class PedidoPostModel
    {
        public DateTime DataPedido { get; set; }
        public decimal Valor { get; set; }
        public Guid IdEnderecoEntrega { get; set; }
        public List<ItemPedidoPostModel> ItensPedido { get; set; }
    }
}
