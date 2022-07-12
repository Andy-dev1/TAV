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
using Xunit;

namespace TransporteDDD.Tests
{
    public class ApplicationServiceTest
    {
        private static Fixture _fixture;
        private Mock<IServicePassageiro> _servicePassageiroMock;
        private Mock<IMapper> _mapperMock;

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
    }
}
