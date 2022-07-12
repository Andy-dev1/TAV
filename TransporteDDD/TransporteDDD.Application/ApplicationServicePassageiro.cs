using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDDD.Application.Dtos;
using TransporteDDD.Application.Interfaces;
using TransporteDDD.Domain.Core.Services;
using TransporteDDD.Domain.Entidades;

namespace TransporteDDD.Application
{
    public class ApplicationServicePassageiro : IApplicationServicePassageiro
    {

        private readonly IServicePassageiro servicePassageiro;
        private readonly IMapper mapper;
        //private readonly IMapper mapper;
        public ApplicationServicePassageiro(IServicePassageiro servicePassageiro, IMapper mapper)
        {
            this.servicePassageiro = servicePassageiro;
            this.mapper = mapper;
        }
        public bool Adicionar(PassageiroDto passageiroDto)
        {
            var passageiro = mapper.Map<Passageiro>(passageiroDto);
            servicePassageiro.Adicionar(passageiro);
            return true;
        }

        public void Atualizar(PassageiroDto passageiroDto)
        {
            var passageiro = mapper.Map<Passageiro>(passageiroDto);
            servicePassageiro.Atualizar(passageiro);
        }

        public PassageiroDto PegarPorId(int id)
        {
            var passageiro = servicePassageiro.PegarPorID(id);
            var passageiroDto = mapper.Map<PassageiroDto>(passageiro);

            return passageiroDto;
        }

        public IEnumerable<PassageiroDto> PegarTodos()
        {
            var passageiros = servicePassageiro.PegarTodos();
            var passageirosDto = mapper.Map<IEnumerable<PassageiroDto>>(passageiros);

            return passageirosDto;
        }

        public void Remover(PassageiroDto passageiroDto)
        {
            var passageiro = mapper.Map<Passageiro>(passageiroDto);
            servicePassageiro.Remover(passageiro);
        }
    }
}
