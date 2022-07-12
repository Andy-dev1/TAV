using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Application.Dtos
{
    public class RelacaoRotaOnibusDto
    {

        public int Id { get; set; }
        public int IdOnibus { get; set; }

        public int IdRota { get; set; }
    }
}
