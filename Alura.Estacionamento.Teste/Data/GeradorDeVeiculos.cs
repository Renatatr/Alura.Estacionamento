using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System.Collections;

namespace Alura.Estacionamento.Teste.Data;

public class GeradorDeVeiculos : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[]{
            new Veiculo()
            { Proprietario = "André Silva",
                Tipo = TipoVeiculo.Motocicleta, //feito de propósito para ver a falha
                Placa = "ABC-0101",
                Modelo = "Fusca"
            },
            new Veiculo()
            { Proprietario = "BBBBBBBBB",
                Tipo = TipoVeiculo.Automovel,
                Placa = "GGG-0101",
                Modelo = "Monza"
            },
            new Veiculo()
            { Proprietario = "CCCCCCCC",
                Tipo = TipoVeiculo.Automovel,
                Placa = "ABC-0101",
                Modelo = "Uno"
            }
        },
        new object[]{
            new Veiculo()
            { Proprietario = "Pedro Silva",
                Tipo = TipoVeiculo.Automovel,
                Placa = "BBC-0101",
                Modelo = "Fusca"
            },
            new Veiculo()
            { Proprietario = "DDDDDDDDDDDDDD",
                Tipo = TipoVeiculo.Automovel,
                Placa = "ASC-0111",
                Modelo = "Camaro"
            },
            new Veiculo()
            { Proprietario = "FFFFFFFFFFF",
                Tipo = TipoVeiculo.Automovel,
                Placa = "TTT-0100",
                Modelo = "Uno"
            }
        }
    };


    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}