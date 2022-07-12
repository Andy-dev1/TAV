using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDDD.Domain.Interfaces;

namespace TransporteDDD.Application
{
    public class ApplicationCalculaTotal : ICalculaTotalReserva
    {
        public bool CalculareValidarValorTotal(double valorTotal, double clienteValorAtual)
        {
            
            if(clienteValorAtual> valorTotal)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

       
    }
}
