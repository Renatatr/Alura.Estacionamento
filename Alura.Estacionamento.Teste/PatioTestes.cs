﻿using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Teste.Data;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Teste;

public class PatioTestes : IDisposable
{

    private Veiculo veiculo;
    private Operador operador;
    public ITestOutputHelper SaidaConsoleTeste;

    public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
    {
        SaidaConsoleTeste = _saidaConsoleTeste;
        SaidaConsoleTeste.WriteLine("Construtor invocado");
        veiculo = new Veiculo();
        operador = new Operador();
        operador.Nome = "paula";
    }

    [Fact]
    public void ValidaFaturamento()
    {
        //arrange
        var estacionamento = new Patio();
        estacionamento.OperadorPatio = operador;
    //    var veiculo = new Veiculo(); -> o construtor faz o trabalho!
        veiculo.Proprietario = "abc";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "f";
        veiculo.Modelo = "de";
        veiculo.Placa = "aaa-9999";
        
        estacionamento.RegistrarEntradaVeiculo(veiculo);
       // Thread.Sleep(10000); dá para testar com segundos, porém, tem o tempo de execução mais o tempo do sleep, o tempo de execução pode não ser tão preciso para validar
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        //Act
        double faturamento = estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(2, faturamento);
    }

    [Theory]
    [InlineData("abc", "aaa-9999", "cor", "modelo")]
    [InlineData("vfr", "tgb-9999", "u", "k")]
    [InlineData("nht", "nhy-9999", "i", "l")]
    public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
    {
        //arrange
        var estacionamento = new Patio();
        estacionamento.OperadorPatio = operador;
        var veiculo = new Veiculo();
        veiculo.Proprietario = proprietario;
        //veiculo.Tipo = TipoVeiculo.Motocicleta; -> padrão é Automóvel (vezes 2)
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;
        veiculo.Placa = placa;

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

        //Act
        double faturamento = estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(2, faturamento);

    }

    [Theory]
    [ClassData(typeof(GeradorDeVeiculos))]
    public void ValidaFaturamentoComVariosVeiculosComObjeto(Veiculo a, Veiculo b, Veiculo c)
    {
        //arrange
        var estacionamento1 = new Patio();
        var estacionamento2 = new Patio();
        var estacionamento3 = new Patio();
        estacionamento1.OperadorPatio = operador;
        estacionamento2.OperadorPatio = operador;
        estacionamento3.OperadorPatio = operador;

        estacionamento1.RegistrarEntradaVeiculo(a);
        estacionamento1.RegistrarSaidaVeiculo(a.Placa);

        estacionamento2.RegistrarEntradaVeiculo(b);
        estacionamento2.RegistrarSaidaVeiculo(b.Placa);

        estacionamento3.RegistrarEntradaVeiculo(c);
        estacionamento3.RegistrarSaidaVeiculo(c.Placa);

        //Act
        double faturamento1 = estacionamento1.TotalFaturado();
        double faturamento2 = estacionamento2.TotalFaturado();
        double faturamento3 = estacionamento3.TotalFaturado();

        //Assert
        Assert.Equal(2, faturamento1);
        Assert.Equal(2, faturamento2);
        Assert.Equal(2, faturamento3);

    }

    [Theory]
    [InlineData("abc", "aaa-9999", "cor", "modelo")]
    public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario, string placa, string cor, string modelo)
    {
        //Arrange
        Patio estacionamento = new Patio();
        estacionamento.OperadorPatio = operador;
        var veiculo = new Veiculo();
        veiculo.Proprietario = proprietario;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;
        veiculo.Placa = placa;

        estacionamento.RegistrarEntradaVeiculo(veiculo);

        //Act
        var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

        //Assert
        Assert.Contains("Ticket Estacionamento", consultado.Ticket);
    }

    [Fact]
    public void TestarAlterarDadosVeiculo()
    {
        //arrange
        Patio estacionamento = new Patio();
        estacionamento.OperadorPatio = operador;
        var veiculo = new Veiculo();
        veiculo.Proprietario = "abc";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "f";
        veiculo.Modelo = "de";
        veiculo.Placa = "aaa-9999";

        estacionamento.RegistrarEntradaVeiculo(veiculo);

        var veiculoAlterado = new Veiculo();
        veiculoAlterado.Proprietario = "abc";
        veiculoAlterado.Tipo = TipoVeiculo.Automovel;
        veiculoAlterado.Cor = "f";
        veiculoAlterado.Modelo = "defefr"; //alterado
        veiculoAlterado.Placa = "aaa-9999";

        //Act
        Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

        //Assert
        Assert.Equal(alterado.Modelo, veiculoAlterado.Modelo);
    }

    public void Dispose()
    {
        SaidaConsoleTeste.WriteLine("Dispose invocado");
    }
}