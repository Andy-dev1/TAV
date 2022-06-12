using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Application.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public int idCliente { get; set; }
        public double valorTotal { get; set; }
        public int idEntrega { get; set; }
    }
}
