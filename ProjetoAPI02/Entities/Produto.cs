using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Entities
{
    public class Produto
    {
        public Guid IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Foto { get; set; }

        //Relacionamento -> TER-MUITOS
        public List<ItemPedido> ItensPedido { get; set; }
    }
}
