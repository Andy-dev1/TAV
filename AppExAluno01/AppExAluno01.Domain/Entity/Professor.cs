using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExAluno01.Domain.Entity
{
    
    public class Professor
    {
        private string id;
        private string name;
        private int age;
        private string cpf;
        private string endereco;
        private int idMateria;
        private Disciplina disciplina;
        public Professor(string id, string name, int age, string cpf, string endereco, int idMateria)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.cpf = cpf;
            this.endereco = endereco;
            disciplina = new Disciplina(idMateria);
            
        }
        public string getMateria()
        {
            return disciplina.getName();
        }
        public bool validaDisciplina()
        {
            return disciplina.validaDisciplina(disciplina.getId());
        }
    }
}
