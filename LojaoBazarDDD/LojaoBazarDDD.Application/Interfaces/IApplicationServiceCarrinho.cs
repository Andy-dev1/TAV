using LojaoBazarDDD.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaoBazarDDD.Application.Interfaces
{
    internal interface IApplicationServiceCarrinho
    {
        bool Adicionar(CarrinhoDto carrinhoDto);

        void Atualizar(CarrinhoDto carrinhoDto);

        void Remover(CarrinhoDto carrinhoDto);

        IEnumerable<CarrinhoDto> PegarTodos();

        CarrinhoDto PegarPorId(int id);
    }
}
