using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabAppEscolaDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);

        void Atualizar(TEntity obj);

        void Remover(TEntity obj);

        IEnumerable<TEntity> PegarTodos();

        TEntity PegarPorID(int id);
    }
}
