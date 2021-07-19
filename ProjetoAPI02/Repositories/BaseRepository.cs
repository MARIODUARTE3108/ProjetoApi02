using Microsoft.EntityFrameworkCore;
using ProjetoAPI02.Contexts;
using ProjetoAPI02.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly SqlServerContext _context;

        public BaseRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Inserir(T obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Alterar(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(T obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<T> Consultar()
        {
            return _context.Set<T>().ToList();
        }

        public T ObterPorId(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}
