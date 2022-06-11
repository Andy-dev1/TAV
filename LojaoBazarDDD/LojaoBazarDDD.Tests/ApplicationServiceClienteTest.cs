using AutoFixture;
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
using LojaoBazarDDD.Domain.Interfaces;
using LojaoBazarDDD.Domain.Core.Services;

namespace LojaoBazarDDD.Tests
{

    public class ApplicationServiceClienteTest
    {

        private static Fixture _fixture;
        private Mock<IServiceCliente> _serviceClienteMock;
        private Mock<IMapper> _mapperMock;

        /*Teste criar carrinho, colocar item no carrinho.
        (Cria carrinho, adicionar telefone) (Se carrinho não existir, instanciar carrinho e depois os objetos.)

         */
        private Mock<ICarrinhoChecker> _carrinhoChekcerMock;
        private Mock<IServiceCarrinho> _serviceCarrinhoMock;

        //Adicionar produtos
        private Mock<IServiceItensCarrinho> _serviceItensCarrinhoMock;

        [Fact]
        public void CarrinhoNaoExiste()
        {
            //Nao existe carrinho
            _carrinhoChekcerMock = new Mock<ICarrinhoChecker>();

            _carrinhoChekcerMock.Setup(x=>x.ExisteCarrinho(0)).Returns(false);

            bool naoExisteCarrinho = _carrinhoChekcerMock.Object.ExisteCarrinho(0);

            Assert.False(naoExisteCarrinho);

            

        }

        [Fact]
        public void InstanciarCarrinho()
        {
            _fixture = new Fixture();
            _serviceCarrinhoMock = new Mock<IServiceCarrinho>();
            _mapperMock = new Mock<IMapper>();
            //Arrange
            const int id = 0;

            var carrinho = _fixture.Build<Carrinho>().With(x=>x.Id,0)
                .Create();

            var carrinhoDto = _fixture.Build<CarrinhoDto>().With(x => x.Id, 0)
                .Create();
            _serviceCarrinhoMock.Setup(x => x.PegarPorID(id)).Returns(carrinho);
            _mapperMock.Setup(x => x.Map<CarrinhoDto>(carrinho)).Returns(carrinhoDto);

            var applicationServiceCarrinho =
                new ApplicationServiceCarrinho(_serviceCarrinhoMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceCarrinho.PegarPorId(id);

            //Assert
            Assert.NotNull(result);
            
            Assert.Equal(id, result.Id);
            _serviceCarrinhoMock.VerifyAll();
            _mapperMock.VerifyAll();
        }

        [Fact]
        public void AdicionaProdutosCarrinho()
        {
            _fixture = new Fixture();
            _serviceItensCarrinhoMock = new Mock<IServiceItensCarrinho>();
            _mapperMock = new Mock<IMapper>();
            //Arrange
            const int id = 10;

            var itensCarrinho = _fixture.Build<ItensCarrinho>()
                .With(c => c.Id, id)
                
                .Create();

            var itensCarrinhoDto = _fixture.Build<ItensCarrinhoDto>()
                .With(c => c.Id, id)
                
                .Create();

            _serviceItensCarrinhoMock.Setup(x => x.PegarPorID(id)).Returns(itensCarrinho);
            _mapperMock.Setup(x => x.Map<ItensCarrinhoDto>(itensCarrinho)).Returns(itensCarrinhoDto);

            var applicationServiceItensCarrinho =
                new ApplicationServiceItensCarrinho(_serviceItensCarrinhoMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceItensCarrinho.PegarPorId(id);

            //Assert
            Assert.NotNull(result);
            //Assert.Equal("teste1@teste.com.br", result.Email);
            Assert.Equal(10, result.Id);
            _serviceItensCarrinhoMock.VerifyAll();
            _mapperMock.VerifyAll();
        }

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

            var applicationServiceCliente = new ApplicationServiceCliente(_serviceClienteMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceCliente.PegarTodos();

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
