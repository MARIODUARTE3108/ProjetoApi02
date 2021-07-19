using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Entities
{
    public class ItemPedido
    {
        public Guid IdItemPedido { get; set; }
        public Guid IdPedido { get; set; }
        public Guid IdProduto { get; set; }
        public int QuantidadeItens { get; set; }

        //Relacionamentos
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}
