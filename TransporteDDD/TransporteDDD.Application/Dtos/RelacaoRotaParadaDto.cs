using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Application.Dtos
{
    public class RelacaoRotaParadaDto
    {
        public int Id { get; set; }
        public int IdRota { get; set; }

        public int IdParada { get; set; }
    }
}
