using AutoMapper;
using LojaoBazarDDD.Application.Dtos;
using LojaoBazarDDD.Domain.Core.Services;
using LojaoBazarDDD.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Application
{
    public class ApplicationServiceCarrinho
    {
        private readonly IServiceCarrinho serviceCarrinho;
        private readonly IMapper mapper;
        //private readonly IMapper mapper;
        public ApplicationServiceCarrinho(IServiceCarrinho serviceCarrinho, IMapper mapper)
        {
            this.serviceCarrinho = serviceCarrinho;
            this.mapper = mapper;
        }
        public bool Adicionar(CarrinhoDto carrinhoDto)
        {
            var carrinho = mapper.Map<Carrinho>(carrinhoDto);
            serviceCarrinho.Adicionar(carrinho);
            return true;
        }

        public void Atualizar(CarrinhoDto carrinhoDto)
        {
            var carrinho = mapper.Map<Carrinho>(carrinhoDto);
            serviceCarrinho.Atualizar(carrinho);
        }

        public CarrinhoDto PegarPorId(int id)
        {
            var carrinho = serviceCarrinho.PegarPorID(id);
            var carrinhoDto = mapper.Map<CarrinhoDto>(carrinho);

            return carrinhoDto;
        }

        public IEnumerable<CarrinhoDto> PegarTodos()
        {
            var carrinhos = serviceCarrinho.PegarTodos();
            var carrinhosDto = mapper.Map<IEnumerable<CarrinhoDto>>(carrinhos);

            return carrinhosDto;
        }

        public void Remover(CarrinhoDto carrinhoDto)
        {
            var carrinho = mapper.Map<Carrinho>(carrinhoDto);
            serviceCarrinho.Remover(carrinho);
        }
    }
}
