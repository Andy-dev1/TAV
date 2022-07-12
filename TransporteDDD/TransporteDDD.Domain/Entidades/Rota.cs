using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Domain.Entidades
{
    public class Rota : Base
    {
        public string Nome { get; set; }

        public bool RotaAtiva { get; set; }

        public float TempoMedioDuracao { get; set; }
    }
}
