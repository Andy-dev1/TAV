using AutoFixture;
using AutoMapper;
using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabAppEscolaDDD.Application;
using TrabAppEscolaDDD.Application.Dtos;
using TrabAppEscolaDDD.Domain.Core.Interfaces.Services;
using TrabAppEscolaDDD.Domain.Entidades;
using Xunit;

namespace TrabAppEscolaDDD.Tests
{
    
    public class ApplicationServiceAlunoTest
    {

        private static Fixture _fixture;
        private Mock<IServiceAluno> _serviceAlunoMock;
        private Mock<IMapper> _mapperMock;

       

        [Fact]
        public void ApplicationServiceCliente_GetAll_ShouldReturnFiveAlunos()
        {
            _fixture = new Fixture();
            _serviceAlunoMock = new Mock<IServiceAluno>();
            _mapperMock = new Mock<IMapper>();

            var alunos =_fixture.Build<Aluno>().CreateMany(5) ;
            var alunosDto = _fixture.Build<AlunoDto>().CreateMany(5);

            _serviceAlunoMock.Setup(x => x.PegarTodos()).Returns(alunos);
            _mapperMock.Setup(x => x.Map<IEnumerable<AlunoDto>>(alunos)).Returns(alunosDto);

            var applicationServiceAluno = new ApplicationServiceAluno(_serviceAlunoMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceAluno.PegarTodos();

            //Assert
            Assert.NotNull(result);
            //Assert.AreEqual(5, result.Count());

            Assert.Equal(5, result.Count());
            _serviceAlunoMock.VerifyAll();
            _mapperMock.VerifyAll();

        }

        [Fact]
        public void ApplicationServiceAluno_GetById_ShouldReturnAluno()
        {
            _fixture = new Fixture();
            _serviceAlunoMock = new Mock<IServiceAluno>();
            _mapperMock = new Mock<IMapper>();
            //Arrange
            const int id = 10;

            var aluno = _fixture.Build<Aluno>()
                .With(c => c.Id, id)
                .With(c => c.Email, "teste1@teste.com.br")
                .Create();

            var alunoDto = _fixture.Build<AlunoDto>()
                .With(c => c.Id, id)
                .With(c => c.Email, "teste1@teste.com.br")
                .Create();

            _serviceAlunoMock.Setup(x => x.PegarPorID(id)).Returns(aluno);
            _mapperMock.Setup(x => x.Map<AlunoDto>(aluno)).Returns(alunoDto);

            var applicationServiceCliente =
                new ApplicationServiceAluno(_serviceAlunoMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceCliente.PegarPorId(id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("teste1@teste.com.br", result.Email);
            Assert.Equal(10, result.Id);
            _serviceAlunoMock.VerifyAll();
            _mapperMock.VerifyAll();


        }
    }
}
