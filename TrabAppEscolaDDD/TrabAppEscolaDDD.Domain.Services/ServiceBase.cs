using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabAppEscolaDDD.Domain.Core.Interfaces.Repositories;
using TrabAppEscolaDDD.Domain.Core.Interfaces.Services;

namespace TrabAppEscolaDDD.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Adicionar(TEntity obj)
        {
            _repository.Adicionar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }

        public TEntity PegarPorID(int id)
        {
            return _repository.PegarPorID(id);
        }

        public IEnumerable<TEntity> PegarTodos()
        {
            return _repository.PegarTodos();
        }

        public void Remover(TEntity obj)
        {
            _repository.Remover(obj);
        }
    }
}
