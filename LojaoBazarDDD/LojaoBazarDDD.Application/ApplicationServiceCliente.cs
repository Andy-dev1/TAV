using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaoBazarDDD.Application.Dtos;
using LojaoBazarDDD.Application.Interfaces;
using LojaoBazarDDD.Domain.Core.Interfaces.Services;
using LojaoBazarDDD.Domain.Entidades;

namespace LojaoBazarDDD.Application
{
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente serviceCliente;
        private readonly IMapper mapper;
        //private readonly IMapper mapper;
        public ApplicationServiceCliente(IServiceCliente serviceCliente, IMapper mapper)
        {
            this.serviceCliente = serviceCliente;
            this.mapper = mapper;
        }
        public bool Adicionar(ClienteDto clienteDto)
        {
            var cliente = mapper.Map<Cliente>(clienteDto);
            serviceCliente.Adicionar(cliente);
            return true;
        }

        public void Atualizar(ClienteDto clienteDto)
        {
            var aluno = mapper.Map<Cliente>(clienteDto);
            serviceCliente.Atualizar(aluno);
        }

        public ClienteDto PegarPorId(int id)
        {
            var cliente = serviceCliente.PegarPorID(id);
            var clienteDto = mapper.Map<ClienteDto>(cliente);

            return clienteDto;
        }

        public IEnumerable<ClienteDto> PegarTodos()
        {
            var clientes = serviceCliente.PegarTodos();
            var clientesDto = mapper.Map<IEnumerable<ClienteDto>>(clientes);

            return clientesDto;
        }

        public void Remover(ClienteDto clienteDto)
        {
            var cliente = mapper.Map<Cliente>(clienteDto);
            serviceCliente.Remover(cliente);
        }
    }
}
