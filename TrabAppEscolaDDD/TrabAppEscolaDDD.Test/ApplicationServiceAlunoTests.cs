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
using TrabAppEscolaDDD.Application.Interfaces;
using TrabAppEscolaDDD.Domain.Core.Interfaces.Repositories;
using TrabAppEscolaDDD.Domain.Core.Interfaces.Services;
using TrabAppEscolaDDD.Domain.Entidades;

namespace TrabAppEscolaDDD.Test
{
    
    public class ApplicationServiceAlunoTests
    {

        private static Fixture _fixture;
        private Mock<IServiceAluno> _serviceAlunoMock;
        private Mock<IMapper> _mapperMock;
        public void ApplicationServiceCliente_GetAll_ShouldReturnFiveAlunos()
        {
            //AlunoDto aluno = new AlunoDto();
            //Arrange
            //Mock<IApplicationServiceAluno> mockAlunoService = new Mock<IApplicationServiceAluno>();
            //mockAlunoService.Setup(m => m.Adicionar(aluno)).Returns(true);

            var alunos = _fixture.Build<Aluno>().CreateMany(5);
            var alunosDto = _fixture.Build<AlunoDto>().CreateMany(5);

            _serviceAlunoMock.Setup(x => x.PegarTodos()).Returns(alunos);
            _mapperMock.Setup(x => x.Map<IEnumerable<AlunoDto>>(alunos)).Returns(alunosDto);

            var applicationServiceAluno = new ApplicationServiceAluno(_serviceAlunoMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceAluno.PegarTodos();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            _serviceClienteMock.VerifyAll();
            _mapperMock.VerifyAll();

        }
    }
}
