using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Security
{
    public class TokenSettings
    {
        //palavra secreta utilizada para criptogtafar o conteudo
        //do token (evitar a falsificação do token)
        public string SecretKey { get; set; }
    }
}
