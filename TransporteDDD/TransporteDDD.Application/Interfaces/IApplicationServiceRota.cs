using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDDD.Application.Dtos;

namespace TransporteDDD.Application.Interfaces
{
    public interface IApplicationServiceRota
    {
        bool Adicionar(RotaDto rotaDto);

        void Atualizar(RotaDto rotaDto);

        void Remover(RotaDto rotaDto);

        IEnumerable<RotaDto> PegarTodos();

        RotaDto PegarPorId(int id);
    }
}
