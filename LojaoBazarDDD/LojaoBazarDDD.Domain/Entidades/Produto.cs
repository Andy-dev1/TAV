using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Domain.Entidades
{
    internal class Produto:Base
    {
        public string Nome { get; set; }
        public int quantidade { get; set; }
        public double preco { get; set; }
        public string fornecedor { get; set; }
    }
}
