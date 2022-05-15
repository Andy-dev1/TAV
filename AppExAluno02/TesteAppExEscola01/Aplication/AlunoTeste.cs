using AppExEscola01.Domain.Entites;
using Application;
using Application.AppService;
using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteAppExEscola01.Aplication
{
    
    public class AlunoTeste
    {
        [Fact]
        public void ValidarAlunoNome()
        {
            //Nome +3 letras - caracteres especiais
            //Arrange
            Aluno aluno = new Aluno(1, "Zeeez", "1234", "11111111111", "11111111");
            //Act
            //Assert
            Assert.True(aluno.ValidaQuantidadeLetras(aluno.getNome()));

        }
        [Fact]
        public void ValidarAlunoCaractere()
        {
            Aluno aluno = new Aluno(1, "Ze da Silva", "1234", "11111111111", "11111111");
            Assert.True(aluno.ValidaNome(aluno.getNome()));
        }
        public void ValidarMatricula()
        {
            Aluno aluno = new Aluno(1, "Ze da Silva", "1234", "20111111111", "11111111");

            Assert.True(aluno.ValidaNome(aluno.getNome()));
        }
        public void AlunoTestCreateAppService()
        {
            //Arrange
            AlunoCreateViewModel alunoIn = new AlunoCreateViewModel("Jose da silva","123","aaa@aa.com","123123");
            AlunoAppService _alunoAppService = new AlunoAppService();
            bool resultEsperado = false;
            //Act
            var result = _alunoAppService.Create(alunoIn);
            //Assert
            Assert.Equal(resultEsperado, result.ResultValidation);
        }
    }
}
}
