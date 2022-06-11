using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Domain.Entidades
{
    public class ItensPedidos:Base
    {
        public int idProduto { get; set; }
        public int quantidade { get; set; }
        public double preco { get; set; }
        
    }
}
