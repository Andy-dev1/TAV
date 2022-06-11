using AutoMapper;
using LojaoBazarDDD.Application.Dtos;
using LojaoBazarDDD.Application.Interfaces;
using LojaoBazarDDD.Domain.Core.Services;
using LojaoBazarDDD.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Application
{
    public class ApplicationServiceItensCarrinho: IApplicationItensCarrinho
    {
        private readonly IServiceItensCarrinho serviceItensCarrinho;
        private readonly IMapper mapper;
        //private readonly IMapper mapper;
        public ApplicationServiceItensCarrinho(IServiceItensCarrinho serviceItensCarrinho, IMapper mapper)
        {
            this.serviceItensCarrinho = serviceItensCarrinho;
            this.mapper = mapper;
        }
        public bool Adicionar(ItensCarrinhoDto itensCarrinhoDto)
        {
            var itensCarrinho = mapper.Map<ItensCarrinho>(itensCarrinhoDto);
            serviceItensCarrinho.Adicionar(itensCarrinho);
            return true;
        }

        public void Atualizar(ItensCarrinhoDto itensCarrinhoDto)
        {
            var itensCarrinho = mapper.Map<ItensCarrinho>(itensCarrinhoDto);
            serviceItensCarrinho.Atualizar(itensCarrinho);
        }

        public ItensCarrinhoDto PegarPorId(int id)
        {
            var itensCarrinho = serviceItensCarrinho.PegarPorID(id);
            var itensCarrinhoDto = mapper.Map<ItensCarrinhoDto>(itensCarrinho);

            return itensCarrinhoDto;
        }

        public IEnumerable<ItensCarrinhoDto> PegarTodos()
        {
            var itensCarrinho = serviceItensCarrinho.PegarTodos();
            var itensCarrinhoDto = mapper.Map<IEnumerable<ItensCarrinhoDto>>(itensCarrinho);

            return itensCarrinhoDto;
        }

        public void Remover(ItensCarrinhoDto itensCarrinhoDto)
        {
            var itensCarrinho = mapper.Map<ItensCarrinho>(itensCarrinhoDto);
            serviceItensCarrinho.Remover(itensCarrinho);
        }
    }
}
