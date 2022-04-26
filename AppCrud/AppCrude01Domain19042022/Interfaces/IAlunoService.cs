using AppCrude01Domain19042022.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCrude01Domain19042022.Interfaces
{
    public interface IAlunoService
    {
        List<Aluno> GetAll();
        Aluno GetById(int id);
        void Add(Aluno aluno);
        void Update(Aluno aluno);
        void Remove(Aluno aluno);
    }
}
