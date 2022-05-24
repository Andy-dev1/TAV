using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabAppEscolaDDD.Domain.Core.Interfaces.Repositories;
using TrabAppEscolaDDD.Domain.Core.Interfaces.Services;
using TrabAppEscolaDDD.Domain.Entidades;

namespace TrabAppEscolaDDD.Domain.Services
{
    public class ServiceAluno : ServiceBase<Aluno>, IServiceAluno
    {
        private readonly IRepositoryAluno _repositoryAluno;
        public ServiceAluno(IRepositoryAluno repositoryAluno) : base(repositoryAluno)
        {
            _repositoryAluno = repositoryAluno;
        }
    }
}
