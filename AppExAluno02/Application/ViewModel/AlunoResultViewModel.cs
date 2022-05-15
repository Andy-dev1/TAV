using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class AlunoResultViewModel
    {
        public string Id { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public bool ResultValidation { get; set; }

        public AlunoResultViewModel(string Id, string Matricula, string Nome, string Cpf, string Email, string Cep, bool ResultValidation)
        {
            this.Id = Id;
            this.Matricula = Matricula;
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.Cep = Cep;
            this.Email = Email;
            this.ResultValidation = ResultValidation;
        }
        public void SetAlunoResultValidation(bool certo)
        {
            this.ResultValidation = certo;
        }

    }
}
