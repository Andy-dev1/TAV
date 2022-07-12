using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteDDD.Application.Dtos;

namespace TransporteDDD.Application.Interfaces
{
    public interface IApplicationServiceRelacaoRotaOnibus
    {
        bool Adicionar(RelacaoRotaOnibusDto RelacaoRotaOnibusDto);

        void Atualizar(RelacaoRotaOnibusDto RelacaoRotaOnibusDto);

        void Remover(RelacaoRotaOnibusDto RelacaoRotaOnibusDto);

        IEnumerable<RelacaoRotaOnibusDto> PegarTodos();

        RelacaoRotaOnibusDto PegarPorId(int id);
    }
}
