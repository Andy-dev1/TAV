using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDDD.Application.Dtos;
using TransporteDDD.Domain.Core.Services;
using TransporteDDD.Domain.Entidades;

namespace TransporteDDD.Application
{
    public class ApplicationServiceReserva
    {
        private readonly IServiceReserva serviceReserva;
        private readonly IMapper mapper;
        //private readonly IMapper mapper;
        public ApplicationServiceReserva(IServiceReserva serviceReserva, IMapper mapper)
        {
            this.serviceReserva = serviceReserva;
            this.mapper = mapper;
        }
        public bool Adicionar(ReservaDto reservaDto)
        {
            var reserva = mapper.Map<Reserva>(reservaDto);
            serviceReserva.Adicionar(reserva);
            return true;
        }

        public void Atualizar(ReservaDto reservaDto)
        {
            var reserva = mapper.Map<Reserva>(reservaDto);
            serviceReserva.Atualizar(reserva);
        }

        public ReservaDto PegarPorId(int id)
        {
            var reserva = serviceReserva.PegarPorID(id);
            var reservaDto = mapper.Map<ReservaDto>(reserva);

            return reservaDto;
        }

        public IEnumerable<ReservaDto> PegarTodos()
        {
            var reservas = serviceReserva.PegarTodos();
            var reservasDto = mapper.Map<IEnumerable<ReservaDto>>(reservas);

            return reservasDto;
        }

        public void Remover(ReservaDto reservaDto)
        {
            var reserva = mapper.Map<Reserva>(reservaDto);
            serviceReserva.Remover(reserva);
        }
    }
}
