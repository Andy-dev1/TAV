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

    public class ApplicationServiceTest
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
        //Fechar pagamento
        private Mock<IServicePedido> _servicePedidoMock;
        


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
            

           

            var itensCarrinhoDto1 = _fixture.Build<ItensCarrinhoDto>()
                .With(c => c.Id, 1)
                .With(c => c.idCarrinho, 0)
                .With(c => c.quantidade, 1)
                .With(c => c.idProduto, 10)
                .With(c => c.nomeProduto, "alho")
                .Create();

            

            var itensCarrinhoDto2 = _fixture.Build<ItensCarrinhoDto>()
                .With(c => c.Id, 2)
                .With(c => c.idCarrinho, 0)
                .With(c => c.quantidade, 4)
                .With(c => c.idProduto, 3)
                .With(c => c.nomeProduto, "feijao")
                .Create();

            
            

            var applicationServiceItensCarrinho =
                new ApplicationServiceItensCarrinho(_serviceItensCarrinhoMock.Object, _mapperMock.Object);

            //Act
            var result1 = applicationServiceItensCarrinho.Adicionar(itensCarrinhoDto1);
            var result2 = applicationServiceItensCarrinho.Adicionar(itensCarrinhoDto2);
            //Assert

            //Assert.true
            Assert.True(result1);
            Assert.True(result2);
            _serviceItensCarrinhoMock.VerifyAll();
            _mapperMock.VerifyAll();
        }

        [Fact]
        public void SimularECalcularFrete()
        {
            Mock<ICorreioService> mock = new Mock<ICorreioService>();
            mock.Setup(m => m.CalculaFrete()).Returns(10.50);
            Frete frete = new Frete(mock.Object)
            {
                Cep = 22224232,
                PesoDosProdutos = 9
            };

            // Act
            double resultado = frete.CalcularFrete();

            // Assert
            Assert.Equal(10.50, resultado);
        }

        [Fact]
        public void FecharPedido()
        {
            //Verificar session
            _fixture = new Fixture();
            _serviceClienteMock = new Mock<IServiceCliente>();
            

            var cliente = _fixture.Build<Cliente>()
                .With(c => c.Id, 0)
                .With(c => c.Email, "teste1@teste.com.br")
                .Create();


            var aplicationServiceClienteVerify = new ApplicationServiceClienteVerify();
            var result = aplicationServiceClienteVerify.ClienteSessionVerify(cliente.Id);

            Assert.True(result);
            //Calcula Total Frete
            var applicationCalculaTotalFrete=new ApplicationCalculaTotalFrete();

            Mock<ICorreioService> mock = new Mock<ICorreioService>();
            mock.Setup(m => m.CalculaFrete()).Returns(15.50);
            Frete frete = new Frete(mock.Object)
            {
                Cep = 22224232,
                PesoDosProdutos = 11
            };

            // Act
            
            double resultado=applicationCalculaTotalFrete.CalculaValorTotalFrete(frete);
            // Assert
            Assert.Equal(15.50, resultado);

            //Adiciona pedido

            _fixture = new Fixture();
           

            var pedido = _fixture.Build<Pedidos>()
                .With(c => c.Id, 20)
                .With(c=>c.valorTotal,100)
                .Create();

            //Calcula valor total + Frete
            var applicationCalculaTotalMaisFrete = new ApplicationCalculaTotalMaisFrete();
            var TotalMaisFrete=applicationCalculaTotalMaisFrete.CalcularValorTotalMaisFrete(resultado, pedido.valorTotal);
            Assert.Equal(115.50, TotalMaisFrete);
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
            

            Assert.Equal(5, result.Count());
            _serviceClienteMock.VerifyAll();
            _mapperMock.VerifyAll();

        }

        [Fact]
        public void FazerPagamento()
        {
            Mock<IApiMercadoPago> mock = new Mock<IApiMercadoPago>();
            var aplicaionFazerPagamento = new ApplicationFazerPagamento();
            mock.Setup(x => x.retornaValorAtual("B7EAF50395C224787C40535BE2E8EBFEEDB86304382551E213D1216A8CBADF96")).Returns(2000);
            var result=aplicaionFazerPagamento.EfetuarPagamento(mock.Object.retornaValorAtual("B7EAF50395C224787C40535BE2E8EBFEEDB86304382551E213D1216A8CBADF96"), 1480);
            Assert.True(result);
        }

        [Fact]
        public void AplicationServiceCadastrarePegarClienteporId()
        {
            _fixture = new Fixture();
            _serviceClienteMock = new Mock<IServiceCliente>();
            _mapperMock = new Mock<IMapper>();
            //Arrange
            const int id = 10;

            var cliente = _fixture.Build<Cliente>()
                .With(c => c.Id, id)
                .With(c=>c.CPF,"123123123123")
                .With(c => c.Nome, "Josue")
                .With(c=>c.Sobrenome,"Xavier")
                .With(c => c.Endereco, "Onde Judas perdeu as botas, 300 ap 9")
                .With(c => c.Email, "josue@teste.com.br")
                .Create();

            var clienteDto = _fixture.Build<ClienteDto>()
                .With(c => c.Id, id)
                .With(c => c.CPF, "123123123123")
                .With(c=>c.Nome,"Josue")
                .With(c => c.Sobrenome, "Xavier")
                .With(c=>c.Endereco,"Onde Judas perdeu as botas, 300 ap 9")
                .With(c => c.Email, "josue@teste.com.br")
                .Create();

            _serviceClienteMock.Setup(x => x.PegarPorID(id)).Returns(cliente);
            _mapperMock.Setup(x => x.Map<ClienteDto>(cliente)).Returns(clienteDto);

            var applicationServiceCliente =
                new ApplicationServiceCliente(_serviceClienteMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceCliente.PegarPorId(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("josue@teste.com.br", result.Email);
            Assert.Equal(10, result.Id);
            _serviceClienteMock.VerifyAll();
            _mapperMock.VerifyAll();


        }
    }
}
