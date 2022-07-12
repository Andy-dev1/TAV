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
    public class ApplicationServiceOnibus : IApplicationServiceOnibus
    {
        private readonly IServiceOnibus serviceOnibus;
        private readonly IMapper mapper;
        //private readonly IMapper mapper;
        public ApplicationServiceOnibus(IServiceOnibus serviceOnibus, IMapper mapper)
        {
            this.serviceOnibus = serviceOnibus;
            this.mapper = mapper;
        }
        public bool Adicionar(OnibusDto onibusDto)
        {
            var onibus = mapper.Map<Onibus>(onibusDto);
            serviceOnibus.Adicionar(onibus);
            return true;
        }

        public void Atualizar(OnibusDto onibusDto)
        {
            var onibus = mapper.Map<Onibus>(onibusDto);
            serviceOnibus.Atualizar(onibus);
        }

        public OnibusDto PegarPorId(int id)
        {
            var onibus = serviceOnibus.PegarPorID(id);
            var onibusDto = mapper.Map<OnibusDto>(onibus);

            return onibusDto;
        }

        public IEnumerable<OnibusDto> PegarTodos()
        {
            var onibus = serviceOnibus.PegarTodos();
            var onibusDtoDto = mapper.Map<IEnumerable<OnibusDto>>(onibus);

            return onibusDtoDto;
        }

        public void Remover(OnibusDto onibusDto)
        {
            var onibus = mapper.Map<Onibus>(onibusDto);
            serviceOnibus.Remover(onibus);
        }
    }
}
