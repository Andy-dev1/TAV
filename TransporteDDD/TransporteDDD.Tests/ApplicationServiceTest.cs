using AutoFixture;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TransporteDDD.Application;
using TransporteDDD.Application.Dtos;
using TransporteDDD.Domain.Core.Services;
using TransporteDDD.Domain.Entidades;
using TransporteDDD.Domain.Interfaces;
using Xunit;

namespace TransporteDDD.Tests
{
    public class ApplicationServiceTest
    {
        private static Fixture _fixture;
        private Mock<IServicePassageiro> _servicePassageiroMock;
        private Mock<IMapper> _mapperMock;

        //Reserva
        private Mock<IServiceReserva> _serviceReservaMock;
        private Mock<IServiceOnibus> _serviceOnibusMock;

        [Fact]
        public void AplicationServiceCadastrarePegarPassageiroporId()
        {
            _fixture = new Fixture();
            _servicePassageiroMock = new Mock<IServicePassageiro>();
            _mapperMock = new Mock<IMapper>();
            //Arrange
            const int id = 10;

            var passageiro = _fixture.Build<Passageiro>()
                .With(c => c.Id, id)
                .With(c => c.CPF, "123123123123")
                .With(c => c.Nome, "Jonas")
                .With(c => c.Sobrenome, "Xavier")
                .With(c => c.Endereco, "Onde Judas perdeu as botas, 300 ap 9")
                .With(c => c.Email, "jonas@teste.com.br")
                .Create();

            var passageiroDto = _fixture.Build<PassageiroDto>()
                .With(c => c.Id, id)
                .With(c => c.CPF, "123123123123")
                .With(c => c.Nome, "Jonas")
                .With(c => c.Sobrenome, "Xavier")
                .With(c => c.Endereco, "Onde Judas perdeu as botas, 300 ap 9")
                .With(c => c.Email, "jonas@teste.com.br")
                .Create();

            _servicePassageiroMock.Setup(x => x.PegarPorID(id)).Returns(passageiro);
            _mapperMock.Setup(x => x.Map<PassageiroDto>(passageiro)).Returns(passageiroDto);

            var applicationServicePassageiro =
                new ApplicationServicePassageiro(_servicePassageiroMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServicePassageiro.PegarPorId(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("jonas@teste.com.br", result.Email);
            Assert.Equal(10, result.Id);
            _servicePassageiroMock.VerifyAll();
            _mapperMock.VerifyAll();


        }

        [Fact]
        public void PegaTodosRetornaCincoPassageiros()
        {
            _fixture = new Fixture();
            _servicePassageiroMock = new Mock<IServicePassageiro>();
            _mapperMock = new Mock<IMapper>();

            var passageiros = _fixture.Build<Passageiro>().CreateMany(5);
            var passageirosDto = _fixture.Build<PassageiroDto>().CreateMany(5);

            _servicePassageiroMock.Setup(x => x.PegarTodos()).Returns(passageiros);
            _mapperMock.Setup(x => x.Map<IEnumerable<PassageiroDto>>(passageiros)).Returns(passageirosDto);

            var applicationServicePassageiro = new ApplicationServicePassageiro(_servicePassageiroMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServicePassageiro.PegarTodos();

            //Assert
            Assert.NotNull(result);


            Assert.Equal(5, result.Count());
            _servicePassageiroMock.VerifyAll();
            _mapperMock.VerifyAll();

        }
        [Fact]
        public void AdicionarMultiplasReservas()
        {
            _fixture = new Fixture();
            _serviceReservaMock = new Mock<IServiceReserva>();
            _mapperMock = new Mock<IMapper>();

            var reservas = _fixture.Build<Reserva>().CreateMany(9);
            var reservasDto = _fixture.Build<ReservaDto>().CreateMany(9);

            _serviceReservaMock.Setup(x => x.PegarTodos()).Returns(reservas);
            _mapperMock.Setup(x => x.Map<IEnumerable<ReservaDto>>(reservas)).Returns(reservasDto);

            var applicationServiceCliente = new ApplicationServiceReserva(_serviceReservaMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceCliente.PegarTodos();

            //Assert
            Assert.NotNull(result);


            Assert.Equal(9, result.Count());
            _serviceReservaMock.VerifyAll();
            _mapperMock.VerifyAll();


        }
        [Fact]
        public void VerificarEspacoeAlocarEmOnibus()
        {
            //Espaco em no onibus
            _fixture = new Fixture();
            _serviceOnibusMock = new Mock<IServiceOnibus>();
            _mapperMock = new Mock<IMapper>();
            //Arrange
            const int id = 10;

            var onibus = _fixture.Build<Onibus>()
                .With(c=>c.Id,9)
                .With(c => c.CapacidadeMaxima, 28)
                .With(c => c.tipoOnibus, "Leito")
                .With(c => c.QntLugares, 11)
                .Create();


            var onibusDto = _fixture.Build<OnibusDto>()
                .With(c => c.Id, 9)
               .With(c => c.CapacidadeMaxima, 28)
               .With(c => c.tipoOnibus, "Leito")
               .With(c => c.QntLugares, 11)
               .Create();


            _serviceOnibusMock.Setup(x => x.PegarPorID(id)).Returns(onibus);
            _mapperMock.Setup(x => x.Map<OnibusDto>(onibus)).Returns(onibusDto);

            var applicationServiceOnibus =
                new ApplicationServiceOnibus(_serviceOnibusMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceOnibus.PegarPorId(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(11, result.QntLugares);
            Assert.Equal(9, result.Id);
            _serviceOnibusMock.VerifyAll();
            _mapperMock.VerifyAll();

            

            
            _serviceReservaMock = new Mock<IServiceReserva>();
            

            var reservas = _fixture.Build<Reserva>().CreateMany(9);
            var reservasDto = _fixture.Build<ReservaDto>().CreateMany(9);

            _serviceReservaMock.Setup(x => x.PegarTodos()).Returns(reservas);
            _mapperMock.Setup(x => x.Map<IEnumerable<ReservaDto>>(reservas)).Returns(reservasDto);

            var applicationServiceCliente = new ApplicationServiceReserva(_serviceReservaMock.Object, _mapperMock.Object);

            //Act
            var resultadoReserva = applicationServiceCliente.PegarTodos();

            //Assert
            Assert.NotNull(result);


            Assert.Equal(9, resultadoReserva.Count());
            _serviceReservaMock.VerifyAll();
            _mapperMock.VerifyAll();

            var applicationServiceVerificarEspaco = new ApplicationVerificarEspaco();
            var resultValidacao=applicationServiceVerificarEspaco.verificar(result.QntLugares, resultadoReserva.Count(), onibusDto.CapacidadeMaxima);
            Assert.True(resultValidacao);
        }
        [Fact]
        public void FecharReserva()
        {
            //Verificar session
            _fixture = new Fixture();
            _servicePassageiroMock = new Mock<IServicePassageiro>();


            var passageiro = _fixture.Build<Passageiro>()
                .With(c => c.Id, 0)
                .With(c => c.Email, "teste1@teste.com.br")
                .With(c=>c.ValorAtual,200)
                .Create();


            var aplicationServicePassageiroVerify = new ApplicationServicePassageiroVerify();
            var result = aplicationServicePassageiroVerify.PassageiroSessionVerify(passageiro.Id);

            Assert.True(result);

            //Rota
            
            //Adiciona reserva

            _fixture = new Fixture();


            var reserva = _fixture.Build<Reserva>()
                .With(c => c.Id, 20)
                .With(c => c.valorTotal, 100)
                .With(c=>c.idOnibus,11)
                .With(c=>c.IdPassageiro,0)
                .With(c=>c.DataReserva, new DateTime(2008, 5, 1, 8, 30, 52))
                .Create();

            //Valida credito para reserva
            var applicationCalculaTotal = new ApplicationCalculaTotal();
            var ValidaCredito = applicationCalculaTotal.CalculareValidarValorTotal(reserva.valorTotal, passageiro.ValorAtual);
            Assert.True(ValidaCredito);
        }
        [Fact]
        public void ReservaPorParada()
        {
            _fixture = new Fixture();
            _serviceReservaMock = new Mock<IServiceReserva>();
            _servicePassageiroMock = new Mock<IServicePassageiro>();
            _mapperMock = new Mock<IMapper>();
            //Arrange

            //Passageiro
            var passageiro = _fixture.Build<PassageiroDto>()
               .With(c => c.Id, 0)
               .With(c => c.Email, "teste1@teste.com.br")
               .With(c => c.ValorAtual, 200)
               .Create();

            //reserva
            var reserva1 = _fixture.Build<ReservaDto>()
                .With(c => c.Id, 1)
                .With(c=>c.idOnibus,0)
                .With(c=>c.IdPassageiro,0)
                .With(c=>c.lugar,"Rio de Janeiro")
                
                .Create();

            //Onibus
            var onibus = _fixture.Build<OnibusDto>()
                .With(c => c.CapacidadeMaxima, 28)
                .With(c => c.IdParadaFinal, "Rio de Janeiro")
                .With(c => c.IdParadaAtual, "Rio de Janeiro")
                .Create();

            //Validar parada atual
            var applicationValida = new ApplicationServiceValidaParada();
            var result = applicationValida.validarParada(reserva1.lugar, onibus.IdParadaAtual);

            Assert.True(result);
            //valido para compra de outra passagem

            var reserva2 = _fixture.Build<ReservaDto>()
                .With(c => c.Id, 2)
                .With(c => c.idOnibus, 2)
                .With(c => c.IdPassageiro, 0)
                .With(c => c.lugar, "Sao Paulo")
                .Create();




            var applicationServiceReserva =
                new ApplicationServiceReserva(_serviceReservaMock.Object, _mapperMock.Object);

            //Act
            applicationServiceReserva.Remover(reserva1);
            var result2 = applicationServiceReserva.Adicionar(reserva2);
            //Assert

            //Assert.true
            
            Assert.True(result2);
            _serviceReservaMock.VerifyAll();
            _mapperMock.VerifyAll();
        }
        [Fact]
        public void FazerPagamento()
        {
            Mock<IApiPagamento> mock = new Mock<IApiPagamento>();
            var aplicaionFazerPagamento = new ApplicationPagamento();
            mock.Setup(x => x.retornaValorAtual("B7EAF50395C224787C404382551E213D1216A8CBADF96")).Returns(2000);
            var result = aplicaionFazerPagamento.EfetuarPagamento(mock.Object.retornaValorAtual("B7EAF50395C224787C404382551E213D1216A8CBADF96"), 1480);
            Assert.True(result);
        }
    }
}
