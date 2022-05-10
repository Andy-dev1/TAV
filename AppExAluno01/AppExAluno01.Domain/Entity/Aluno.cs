using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppExAluno01.Domain.Entity
{
    public class Aluno
    {
        private string id;
        private string name;
        private int age;
        private string cpf;
        private string endereco;
        private string matricula;
        

        public Aluno(string id, string name, int age,string cpf, string endereco, string matricula)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.cpf = cpf; 
            this.endereco = endereco;
            this.matricula = matricula;
        }

     
        public bool validaMatricula(string matricula)
        {
            string substring = matricula.Substring(0,4);
            int year = Int32.Parse(substring);
            
            if (year >= 2010)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool validaNome(string name)
        {
            var regexItem = new Regex("^[a-zA-Z ]*$");
            if (regexItem.IsMatch(name)) {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public string getName()
        {
            return name;
        }
        public string getMat()
        {
            return matricula;
        }
        
    }
}
