using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Application.Dtos
{
    public class OnibusDto
    {
        public int Id { get; set; }
        public int CapacidadeMaxima { get; set; }
        public string IdRotaAtual { get; set; }
        public string IdParadaFinal { get; set; }
        public string IdParadaAtual { get; set; }
        public int QntLugares { get; set; }
    }
}
