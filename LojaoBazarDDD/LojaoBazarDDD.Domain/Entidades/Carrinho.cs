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
        //public ICarrinhoChecker carrinhoChecker { get; set; }

        /*public static Carrinho Create(int id,DateTime dataCompra, double valorTotal, double frete)
        {
            return new Carrinho(id,dataCompra, valorTotal, frete);
        }

        public Carrinho(int id,DateTime dataCompra, double valorTotal, double frete)
        {
            Id = id;
            this.dataCompra = dataCompra;
            this.valorTotal = valorTotal;
            this.frete = frete;
        }*/

        
    }
}
