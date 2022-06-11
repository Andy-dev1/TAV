using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Application.Dtos
{
    public class CarrinhoDto
    {
        public int Id { get; set; }
        public DateTime dataCompra { get; set; }
        public double valorTotal { get; set; }
        public double frete { get; set; }
    }
}
