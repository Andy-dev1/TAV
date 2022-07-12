using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Application.Dtos
{
    public class ReservaDto
    {
        public int Id { get; set; }

        public DateTime DataReserva { get; set; }

        public int IdPassageiro { get; set; }

        public int idOnibus { get; set; }

        public int lugar { get; set; }

        public int valorTotal { get; set; }
    }
}
