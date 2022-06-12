using LojaoBazarDDD.Domain.Entidades;
using LojaoBazarDDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Application
{
    public class ApplicationCalculaTotalFrete : ICalcularValorTotalFrete
    {
        public ApplicationCalculaTotalFrete()
        {
        }

        public double CalculaValorTotalFrete(Frete frete)
        {
            return frete.CalcularFrete();
        }

    }
}
