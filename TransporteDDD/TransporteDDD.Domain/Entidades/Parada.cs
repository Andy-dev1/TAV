using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Domain.Entidades
{
    public class Parada:Base
    {
        public string Nome { get; set; }
        public string Lugar { get; set; }
    }
}
