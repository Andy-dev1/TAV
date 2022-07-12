using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Application.Dtos
{
    public class RotaDto
    {
        public string Nome { get; set; }

        public bool RotaAtiva { get; set; }

        public float TempoMedioDuracao { get; set; }
    }
}
