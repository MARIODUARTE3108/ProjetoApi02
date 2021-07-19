using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Entities
{
    public class Pedido
    {
        public Guid IdPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal Valor { get; set; }
        public Guid IdCliente { get; set; }
        public Guid? IdEndereco { get; set; }

        //Relacionamento -> TER-1
        public Cliente Cliente { get; set; }

        //Relacionamento -> TER-1
        public Endereco EnderecoEntrega { get; set; }

        //Relacionamento -> TER-MUITOS
        public List<ItemPedido> ItensPedido { get; set; }

    }
}
