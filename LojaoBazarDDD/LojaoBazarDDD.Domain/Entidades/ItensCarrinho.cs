using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Domain.Entidades
{
    public class ItensCarrinho : Base
    {
        public int idCarrinho { get; set; }
        public int idProduto { get; set; }
        public int quantidade { get; set; }
        public double preco { get; set; }
        public string nomeProduto { get; set; }

        /*public double SimularFrete()
        {
            return 0;
        }*/
    }
}
