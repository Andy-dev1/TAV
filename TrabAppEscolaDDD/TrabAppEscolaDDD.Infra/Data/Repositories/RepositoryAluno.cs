using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabAppEscolaDDD.Domain.Core.Interfaces.Repositories;
using TrabAppEscolaDDD.Domain.Entidades;

namespace TrabAppEscolaDDD.Infra.Data.Repositories
{
    public class RepositoryAluno : RepositoryBase<Aluno>, IRepositoryAluno
    {
        private readonly SqlContext _sqlContext;
        public RepositoryAluno(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
