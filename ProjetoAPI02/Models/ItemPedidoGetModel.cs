using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Models
{
    public class ItemPedidoGetModel
    {
        public int IdItemPedido { get; set; }
        public int QuantidadeItens { get; set; }

        public ProdutoGetModel Produto { get; set; }
    }
}
