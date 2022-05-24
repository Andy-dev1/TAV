using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabAppEscolaDDD.Domain.Core.Interfaces.Repositories;

namespace TrabAppEscolaDDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext _sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public void Adicionar(TEntity obj)
        {
            try
            {
                _sqlContext.Set<TEntity>().Add(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Atualizar(TEntity obj)
        {
            try
            {
                _sqlContext.Entry(obj).State = EntityState.Modified;
                _sqlContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TEntity PegarPorID(int id)
        {
            return _sqlContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> PegarTodos()
        {
            return _sqlContext.Set<TEntity>().ToList();
        }

        public void Remover(TEntity obj)
        {
            try
            {
                _sqlContext.Set<TEntity>().Remove(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
