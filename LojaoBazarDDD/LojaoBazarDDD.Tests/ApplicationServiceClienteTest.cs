﻿using AutoFixture;
using AutoMapper;
using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaoBazarDDD.Application;
using LojaoBazarDDD.Application.Dtos;
using LojaoBazarDDD.Domain.Core.Interfaces.Services;
using LojaoBazarDDD.Domain.Entidades;
using Xunit;

namespace LojaoBazarDDD.Tests
{

    public class ApplicationServiceClienteTest
    {

        private static Fixture _fixture;
        private Mock<IServiceCliente> _serviceClienteMock;
        private Mock<IMapper> _mapperMock;



        [Fact]
        public void PegaTodosRetornaCincoClientes()
        {
            _fixture = new Fixture();
            _serviceClienteMock = new Mock<IServiceCliente>();
            _mapperMock = new Mock<IMapper>();

            var clientes = _fixture.Build<Cliente>().CreateMany(5);
            var clientesDto = _fixture.Build<ClienteDto>().CreateMany(5);

            _serviceClienteMock.Setup(x => x.PegarTodos()).Returns(clientes);
            _mapperMock.Setup(x => x.Map<IEnumerable<ClienteDto>>(clientes)).Returns(clientesDto);

            var applicationServiceAluno = new ApplicationServiceCliente(_serviceClienteMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceAluno.PegarTodos();

            //Assert
            Assert.NotNull(result);
            //Assert.AreEqual(5, result.Count());

            Assert.Equal(5, result.Count());
            _serviceClienteMock.VerifyAll();
            _mapperMock.VerifyAll();

        }

        [Fact]
        public void AplicationServiceClienteGetBYIdDeveRetornarCliente()
        {
            _fixture = new Fixture();
            _serviceClienteMock = new Mock<IServiceCliente>();
            _mapperMock = new Mock<IMapper>();
            //Arrange
            const int id = 10;

            var cliente = _fixture.Build<Cliente>()
                .With(c => c.Id, id)
                .With(c => c.Email, "teste1@teste.com.br")
                .Create();

            var clienteDto = _fixture.Build<ClienteDto>()
                .With(c => c.Id, id)
                .With(c => c.Email, "teste1@teste.com.br")
                .Create();

            _serviceClienteMock.Setup(x => x.PegarPorID(id)).Returns(cliente);
            _mapperMock.Setup(x => x.Map<ClienteDto>(cliente)).Returns(clienteDto);

            var applicationServiceCliente =
                new ApplicationServiceCliente(_serviceClienteMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceCliente.PegarPorId(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("teste1@teste.com.br", result.Email);
            Assert.Equal(10, result.Id);
            _serviceClienteMock.VerifyAll();
            _mapperMock.VerifyAll();


        }
    }
}