using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Entities
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        //Relacionamento -> TER-MUITOS
        public List<Pedido> Pedidos { get; set; }

        //Relacionamento -> TER-MUITOS
        public List<Endereco> Enderecos { get; set; }

    }
}
