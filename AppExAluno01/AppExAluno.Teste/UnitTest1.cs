using Xunit;
using AppExAluno01.Domain.Entity;
using System.Diagnostics;

namespace AppExAluno.Teste
{
    public class UnitTest1
    {
        [Fact]
        public void ValidaNome()
        {
            Aluno aluno = new Aluno("0", "Joelson", 32, "111111111111", "Onde o Judas perdeu as botas", "201023232");
            Assert.True(aluno.validaNome(aluno.getName()));
        }
        [Fact]
        public void ValidaMatricula()
        {
            Aluno aluno = new Aluno("0", "Joelson", 32, "111111111111", "Onde o Judas perdeu as botas", "201123232");
            Assert.True(aluno.validaMatricula(aluno.getMat()));
            
        }

        [Fact]
        public void getDisciplina()
        {
           Professor professor = new Professor("0", "marcos", 30, "11111111111", "Barra", 0);
            Assert.Equal("matematica", professor.getMateria());
        }
        [Fact]
        public void validaDisciplina()
        {
            Professor professor = new Professor("0", "marcos", 30, "11111111111", "Barra", 0);
            Assert.True(professor.validaDisciplina());
        }
    }
}