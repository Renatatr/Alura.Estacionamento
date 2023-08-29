using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Teste;

public class VeiculoTestes : IDisposable
{
    private Veiculo veiculo;
    public ITestOutputHelper SaidaConsoleTeste;

    public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
    {
        SaidaConsoleTeste = _saidaConsoleTeste;
        SaidaConsoleTeste.WriteLine("Construtor invocado");
        veiculo = new Veiculo();
    }

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
       // var veiculo = new Veiculo(); -> a propriedade é suficiente ...
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

    [Fact]
    public void FichaDeDadosVeiculo()
    {
        //Arrage
        var carro = new Veiculo();
        carro.Proprietario = "ewq";
        carro.Tipo = TipoVeiculo.Automovel;
        carro.Cor = "fqwe";
        carro.Modelo = "ewqr";
        carro.Placa = "www-9999";

        //Act
        string dados = carro.ToString();

        //Assert
        Assert.Contains("Tipo do Veículo:", dados);
    }

    public void Dispose()
    {
        SaidaConsoleTeste.WriteLine("Dispose invocado. \nExecução do Cleanup: Limpando os objetos.");
    }
}