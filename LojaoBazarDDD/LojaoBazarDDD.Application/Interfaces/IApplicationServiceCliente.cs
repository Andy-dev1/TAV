using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaoBazarDDD.Application.Dtos;

namespace LojaoBazarDDD.Application.Interfaces
{
    public interface IApplicationServiceCliente
    {
        bool Adicionar(ClienteDto clienteDto);

        void Atualizar(ClienteDto clienteDto);

        void Remover(ClienteDto clienteDto);

        IEnumerable<ClienteDto> PegarTodos();

        ClienteDto PegarPorId(int id);
    }
}
