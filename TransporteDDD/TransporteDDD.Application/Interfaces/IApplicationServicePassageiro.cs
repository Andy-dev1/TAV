using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDDD.Application.Dtos;

namespace TransporteDDD.Application.Interfaces
{
    public interface IApplicationServicePassageiro
    {
        bool Adicionar(PassageiroDto passageiroDto);

        void Atualizar(PassageiroDto passageiroDto);

        void Remover(PassageiroDto passageiroDto);

        IEnumerable<PassageiroDto> PegarTodos();

        PassageiroDto PegarPorId(int id);
    }
}
