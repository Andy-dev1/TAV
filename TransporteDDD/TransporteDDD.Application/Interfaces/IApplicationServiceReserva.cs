using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDDD.Application.Dtos;

namespace TransporteDDD.Application.Interfaces
{
    public interface IApplicationServiceReserva
    {
        bool Adicionar(ReservaDto reservaDto);

        void Atualizar(ReservaDto reservaDto);

        void Remover(ReservaDto reservaDto);

        IEnumerable<ReservaDto> PegarTodos();

        ReservaDto PegarPorId(int id);
    }
}
