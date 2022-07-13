using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Domain.Entidades
{
    public class Reserva : Base
    {
        public DateTime DataReserva { get; set; }

        public int IdPassageiro { get; set; }

        public int idOnibus { get; set; }

        public string lugar { get; set; }

        public int valorTotal { get; set; }
    }
}
