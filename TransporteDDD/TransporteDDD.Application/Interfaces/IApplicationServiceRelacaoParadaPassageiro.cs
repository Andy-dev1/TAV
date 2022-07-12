using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDDD.Application.Dtos;

namespace TransporteDDD.Application.Interfaces
{
    public interface IApplicationServiceRelacaoParadaPassageiro
    {
        bool Adicionar(RelacaoParadaPassageiroDto relacaoParadaPassageiroDto);

        void Atualizar(RelacaoParadaPassageiroDto relacaoParadaPassageiroDto);

        void Remover(RelacaoParadaPassageiroDto relacaoParadaPassageiroDto);

        IEnumerable<RelacaoParadaPassageiroDto> PegarTodos();

        RelacaoParadaPassageiroDto PegarPorId(int id);
    }
}
