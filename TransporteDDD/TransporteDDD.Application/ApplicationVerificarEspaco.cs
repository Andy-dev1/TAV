using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Application
{
    public class ApplicationVerificarEspaco
    {
        public bool verificar(int espacoatual,int espacoAlocado,int espacoMaximo)
        {
            if(espacoMaximo >= espacoAlocado+ espacoatual)
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
