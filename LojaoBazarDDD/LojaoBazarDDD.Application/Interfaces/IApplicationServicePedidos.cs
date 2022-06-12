using LojaoBazarDDD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Application.Interfaces
{
    public interface IApplicationServicePedidos
    {
        bool Adicionar(PedidoDto pedidoDto);

        void Atualizar(PedidoDto pedidoDto);

        void Remover(PedidoDto pedidoDto);

        IEnumerable<PedidoDto> PegarTodos();

        PedidoDto PegarPorId(int id);
    }
}
