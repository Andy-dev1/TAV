using LojaoBazarDDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Application
{
    public class ApplicationFazerPagamento : IFazerPagamento
    {
        public bool EfetuarPagamento(double valorAtual, double valorTotal)
        {
            return valorAtual > valorTotal;
        }
    }
}
