using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI02.Interfaces
{
    //<T> tipo de dado generico, irá representar
    //qualquer classe de entidade do projeto
    public interface IBaseRepository<T>
        where T : class
    {
        void Inserir(T obj);
        void Alterar(T obj);
        void Excluir(T obj);

        List<T> Consultar();
        T ObterPorId(Guid id);
    }
}
