using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteDDD.Domain.Entidades
{
    public class RelacaoRotaOnibus:Base
    {
        public int IdOnibus { get; set; }

        public int IdRota { get; set; }
    }
}
