using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Application
{
    public class ApplicationServiceValidaParada
    {
        public bool validarParada(string paradaAtual,string paradaFinal)
        {
            if(paradaAtual == paradaFinal)
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
