using ProjetoAPI02.Contexts;
using ProjetoAPI02.Entities;
using ProjetoAPI02.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        private readonly SqlServerContext _context;

        public EnderecoRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public List<Endereco> ConsultarPorCliente(Guid idCliente)
        {
            return _context.Endereco
                    .Where(e => e.IdCliente.Equals(idCliente))
                    .ToList();
        }
    }
}