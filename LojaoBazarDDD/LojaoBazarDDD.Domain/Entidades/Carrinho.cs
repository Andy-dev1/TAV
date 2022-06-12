using LojaoBazarDDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Domain.Entidades
{
    public class Carrinho:Base
    {
        public DateTime dataCompra { get; set; }
        public double valorTotal { get; set; }
        public double frete { get; set; }
        

        
    }
}
