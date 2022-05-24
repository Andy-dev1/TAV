﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabAppEscolaDDD.Domain.Entidades
{
    public class Aluno:Base
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Matricula { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
    }
}
