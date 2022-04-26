using AppCrude01Domain19042022.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCrude01Domain19042022.Interfaces
{
    interface IAlunoRepository
    {
        List<Aluno> GetAll();
        IAlunoService GetById(int id);
        void Create(IAlunoService aluno);
        void Update(IAlunoService aluno);
        void Delete(IAlunoService aluno);
    }
}
