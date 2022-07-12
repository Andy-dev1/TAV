using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDDD.Application.Dtos;

namespace TransporteDDD.Application.Interfaces
{
    public interface IApplicationServiceParada
    {
        bool Adicionar(ParadaDto paradaDto);

        void Atualizar(ParadaDto paradaDto);

        void Remover(ParadaDto paradaDto);

        IEnumerable<ParadaDto> PegarTodos();

        ParadaDto PegarPorId(int id);
    }
}
