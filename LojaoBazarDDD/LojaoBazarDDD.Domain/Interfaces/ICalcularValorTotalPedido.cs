using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Domain.Interfaces
{
    public interface ICalcularValorTotalPedido
    {
        double CalcularValorTotalMaisFrete(double frete, double valorTotal);
    }
}
