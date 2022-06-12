using LojaoBazarDDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Application
{
    public class ApplicationCalculaTotalMaisFrete : ICalcularValorTotalPedido
    {
        public ApplicationCalculaTotalMaisFrete()
        {
        }

        public double CalcularValorTotalMaisFrete(double frete, double valorTotal)
        {
            return frete + valorTotal;
        }

    }
}
