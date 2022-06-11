using LojaoBazarDDD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Application.Interfaces
{
    public interface IApplicationItensCarrinho
    {
        bool Adicionar(ItensCarrinhoDto itensCarrinhoDto);

        void Atualizar(ItensCarrinhoDto itensCarrinhoDto);

        void Remover(ItensCarrinhoDto itensCarrinhoDto);

        IEnumerable<ItensCarrinhoDto> PegarTodos();

        ItensCarrinhoDto PegarPorId(int id);
    }
}
