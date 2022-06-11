using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Domain.Interfaces
{
    public interface IProcuraProduto
    {
        double getPeso(int idProduto);
    }
}
