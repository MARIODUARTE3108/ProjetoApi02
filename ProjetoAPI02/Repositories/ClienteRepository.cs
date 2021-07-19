using ProjetoAPI02.Contexts;
using ProjetoAPI02.Entities;
using ProjetoAPI02.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly SqlServerContext _context;

        public ClienteRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public Cliente ObterPorEmail(string email)
        {
            return _context.Cliente
                    .FirstOrDefault(c => c.Email.Equals(email));
        }

        public Cliente ObterPorEmailESenha(string email, string senha)
        {
            return _context.Cliente
                    .FirstOrDefault(c => c.Email.Equals(email)
                                      && c.Senha.Equals(senha));
        }
    }
}