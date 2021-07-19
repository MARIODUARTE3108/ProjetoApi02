using ProjetoAPI02.Contexts;
using ProjetoAPI02.Entities;
using ProjetoAPI02.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly SqlServerContext _context;

        public ProdutoRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
    }
}
