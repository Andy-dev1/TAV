using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Domain.Interfaces
{
    public interface IApiPagamento
    {
        double retornaValorAtual(string clienteToken);
    }
}
