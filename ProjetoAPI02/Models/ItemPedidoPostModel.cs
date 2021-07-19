using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Models
{
    public class ItemPedidoPostModel
    {
        public Guid IdProduto { get; set; }
        public int QuantidadeItens { get; set; }
    }
}
