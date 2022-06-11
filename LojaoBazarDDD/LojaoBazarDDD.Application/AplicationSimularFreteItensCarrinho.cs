using LojaoBazarDDD.Application.Dtos;
using LojaoBazarDDD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Application
{
    public class AplicationSimularFreteItensCarrinho : IItensCarrinhoFrete<ItensCarrinhoDto>
    {
        private double pesoDosProdutos;
        private string cep;
        public AplicationSimularFreteItensCarrinho(double peso,string cep)
        {
            this.pesoDosProdutos = peso;
            this.cep = cep;
        }

        public double SimularFrete(ItensCarrinhoDto obj)
        {
            //var result=obj.Select(x=>x.quantidade).ToList().Sum();
            return 4;
        }
    }
}
