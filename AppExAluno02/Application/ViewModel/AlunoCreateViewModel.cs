using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class AlunoCreateViewModel
    {
        
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public AlunoCreateViewModel(string nome, string cpf, string email, string cep)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Email = email;
            this.Cep = cep;
            
        }
    }
}
