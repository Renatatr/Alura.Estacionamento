using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Teste;

public class VeiculoTestes
{
    [Fact(DisplayName = "Primeiro teste")]
    [Trait("Funcionalidade","Acelerar")]
    public void TestaVeiculoAcelerar()
    {
        //Arrange
        var veiculo = new Veiculo();
        //Act
        veiculo.Acelerar(10);
        //Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaVeiculoFrear()
    {
        var veiculo = new Veiculo();
        veiculo.Frear(10);
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaTipoVeiculo()
    {
        //Arrange
        var veiculo = new Veiculo();
        //Act            
        //Assert
        Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }

    [Fact]
    public void TestaTipoVeiculo2()
    {
        //Arrange
        var veiculo = new Veiculo();
        //Act
        veiculo.Tipo = (TipoVeiculo)1;
        //Assert
        Assert.Equal(TipoVeiculo.Motocicleta, veiculo.Tipo);
    }

    [Fact(DisplayName = "teste", Skip = "Teste ainda não implementado. Ignorar.")]
    public void ValidaNomeProprietario()
    {

    }
}