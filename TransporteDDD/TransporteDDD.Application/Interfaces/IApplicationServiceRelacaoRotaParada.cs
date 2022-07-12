using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDDD.Application.Dtos;

namespace TransporteDDD.Application.Interfaces
{
    public interface IApplicationServiceRelacaoRotaParada
    {
        bool Adicionar(RelacaoRotaParadaDto relacaoRotaParadaDto);

        void Atualizar(RelacaoRotaParadaDto relacaoRotaParadaDto);

        void Remover(RelacaoRotaParadaDto relacaoRotaParadaDto);

        IEnumerable<RelacaoRotaParadaDto> PegarTodos();

        RelacaoRotaParadaDto PegarPorId(int id);
    }
}
