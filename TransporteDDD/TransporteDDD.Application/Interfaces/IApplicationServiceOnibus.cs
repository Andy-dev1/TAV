using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDDD.Application.Dtos;

namespace TransporteDDD.Application.Interfaces
{
    public interface IApplicationServiceOnibus
    {
        bool Adicionar(OnibusDto onibusDto);

        void Atualizar(OnibusDto onibusDto);

        void Remover(OnibusDto onibusDto);

        IEnumerable<OnibusDto> PegarTodos();

        OnibusDto PegarPorId(int id);
    }
}
