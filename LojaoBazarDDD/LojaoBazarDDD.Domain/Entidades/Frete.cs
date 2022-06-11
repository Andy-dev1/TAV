using LojaoBazarDDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Domain.Entidades
{
    public class Frete : Base
    {
        public int Cep { get; set; }
        public double PesoDosProdutos { get; set; }

        private ICorreioService correioService;

        public Frete(ICorreioService _correioService)
        {
            correioService = _correioService;
        }

        public double CalcularFrete()
        {
            return correioService.CalculaFrete();
        }
    }
}
