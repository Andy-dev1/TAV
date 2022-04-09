using System;
using Xunit;
using AppFreteFinal;
using Moq;


namespace AppFreteTestFinal
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            
            //Arrange
            Mock<ICorreioService> mock1 = new Mock<ICorreioService>();
            mock1.Setup(m => m.CalcularFrete()).Returns(7.52);
            Mock<IParametrosService> mock2 = new Mock<IParametrosService>();
            mock2.Setup(m => m.AdicionalFrete()).Returns(1.00);
            Frete frete = new Frete(mock1.Object, mock2.Object)
            {
                Cep = 21857818,
                Peso = 5
            };
            //Act
            double resultado = frete.CalcularFrete();
            //Assert
            Assert.Equal(8.52,resultado);

        }
    }
}
