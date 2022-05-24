using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabAppEscolaDDD.Application.Dtos;

namespace TrabAppEscolaDDD.Application.Interfaces
{
    public interface IApplicationServiceAluno
    {
        bool Adicionar(AlunoDto alunoDto);

        void Atualizar(AlunoDto alunoDto);

        void Remover(AlunoDto alunoDto);

        IEnumerable<AlunoDto> PegarTodos();

        AlunoDto PegarPorId(int id);
    }
}
