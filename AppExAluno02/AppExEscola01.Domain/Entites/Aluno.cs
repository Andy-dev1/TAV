using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppExEscola01.Domain.Entites
{
    public class Aluno
    {
        private int baseYear=2010;
        private int idAluno { get; set; }
        private string nomeAluno { get; set; }
        private string matriculaAluno { get; set; }
        private string CPFAluno { get; set; }
        private string dataNascimentoAluno { get; set; }
        private string Cep { get; set; }
        public Aluno(AlunoCreateViewModel aluno)
        {
            this.Cep = aluno.Cep;
            nomeAluno = aluno.Nome;
            
            CPFAluno = aluno.Cpf;
           
        }
        public bool ValidaNome(string nome)
        {
                var regexItem = new Regex("^[a-zA-Z ]*$");
                if (regexItem.IsMatch(nome)) {
                    return true;
                }
                else
                {
                    return false;
                }
            
        }
        public bool ValidaQuantidadeLetras(string nome)
        {
            if (nome.Length > 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidaMatricula(string matricula)
        {
            string substring = matricula.Substring(0, 4);
            int ano = Int32.Parse(substring);
            if (ano > baseYear)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public string getMatricula()
        {
            return matriculaAluno;
        }
        public string getNome()
        {
            return nomeAluno;
        }
    }
}
