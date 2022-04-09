using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFreteFinal
{
    public class Frete
    {
        public int Cep { get; set; }
        public double Peso { get; set; }

        private ICorreioService correioService;
        private IParametrosService parametrosService;

        public Frete(ICorreioService _correioService,IParametrosService _parametrosService)
        {
            correioService = _correioService;
            parametrosService = _parametrosService;
        }

        public double CalcularFrete() {
            return correioService.CalcularFrete() + parametrosService.AdicionalFrete();
        }
    }
}
