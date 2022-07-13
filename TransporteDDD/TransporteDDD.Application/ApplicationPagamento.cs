using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Application
{
    public class ApplicationPagamento
    {
        public bool EfetuarPagamento(double valorAtual, double valorTotal)
        {
            return valorAtual > valorTotal;
        }
    }
}
