using ProjetoAPI02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente ObterPorEmail(string email);
        Cliente ObterPorEmailESenha(string email, string senha);
    }
}
