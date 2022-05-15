using Application.Interfaces;
using Application.ViewModel;

namespace Application.AppService
{
    public class AlunoAppService : IAlunoAppService
    {
        public AlunoResultViewModel Create(AlunoCreateViewModel aluno) 
        {
            Aluno alunoNew = new Aluno(aluno);
            AlunoResultViewModel alunoResult = new AlunoResultViewModel("1","22222222222","Jose da silva", "123", "aaa@aa.com", "123123",false);
            alunoResult.SetAlunoResultValidation(false);
            return alunoResult;
        }
    }
}
