using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Domain.Entidades
{
    public class Pedidos : Base
    {
        public int idCliente { get; set; }
        public double valorTotal { get; set; }
        public int idEntrega { get; set; }
       
        public double CalcularValorTotalPedido()
        {
            return valorTotal;
        }

        public double CalcularValorTotalFrete()
        {
            return valorTotal;
        }
    }
}
