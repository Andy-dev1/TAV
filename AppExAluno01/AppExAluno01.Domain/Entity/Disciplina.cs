using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppExAluno01.Domain.Entity
{
    public class Disciplina
    {
        string[] fixedDisciplina = { "matematica", "portugues", "geografia", "fisica","historia" };
        private int id;
        
        
        public Disciplina(int id)
        {
            this.id = id;
            
        }
        public string getName()
        {
            return fixedDisciplina[id];
        }
        public bool validaDisciplina(int id)
        {
            if(id>=0 && id < fixedDisciplina.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int getId()
        {
            return id;
        }
    }
}
