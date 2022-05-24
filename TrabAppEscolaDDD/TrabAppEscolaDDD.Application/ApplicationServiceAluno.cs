using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabAppEscolaDDD.Application.Dtos;
using TrabAppEscolaDDD.Application.Interfaces;
using TrabAppEscolaDDD.Domain.Core.Interfaces.Services;
using TrabAppEscolaDDD.Domain.Entidades;

namespace TrabAppEscolaDDD.Application
{
    public class ApplicationServiceAluno : IApplicationServiceAluno
    {
        private readonly IServiceAluno serviceAluno;
        private readonly IMapper mapper;
        //private readonly IMapper mapper;
        public ApplicationServiceAluno(IServiceAluno serviceAluno,IMapper mapper)
        {
            this.serviceAluno = serviceAluno;
            this.mapper = mapper;
        }
        public bool Adicionar(AlunoDto alunoDto)
        {
            var aluno = mapper.Map<Aluno>(alunoDto);
            serviceAluno.Adicionar(aluno);
            return true;
        }

        public void Atualizar(AlunoDto alunoDto)
        {
            var aluno = mapper.Map<Aluno>(alunoDto);
            serviceAluno.Atualizar(aluno);
        }

        public AlunoDto PegarPorId(int id)
        {
            var aluno = serviceAluno.PegarPorID(id);
            var alunoDto = mapper.Map<AlunoDto>(aluno);

            return alunoDto;
        }

        public IEnumerable<AlunoDto> PegarTodos()
        {
            var alunos = serviceAluno.PegarTodos();
            var alunosDto = mapper.Map<IEnumerable<AlunoDto>>(alunos);

            return alunosDto;
        }

        public void Remover(AlunoDto alunoDto)
        {
            var aluno = mapper.Map<Aluno>(alunoDto);
            serviceAluno.Remover(aluno);
        }
    }
}
