using JuegoBolillero;

namespace JuegoBolillero.Tests;

public class BolilleroTest
{
    private Bolillero _bolillero;

    public BolilleroTest()
    {
        var bolillas = Enumerable.Range(0, 10).ToList(); // [0..9]
        _bolillero = new Bolillero(bolillas, new Primero());
    }

    [Fact]
    public void SacarBolilla()
    {
        var bolilla = _bolillero.SacarBolilla();

        Assert.Equal(0, bolilla);
        Assert.Equal(9, _bolillero.BolillasAdentro.Count);
        Assert.Equal(1, _bolillero.BolillasFuera.Count);
    }

    [Fact]
    public void ReIngresar()
    {
        _bolillero.SacarBolilla();
        _bolillero.Revocar();

        Assert.Equal(10, _bolillero.BolillasAdentro.Count);
        Assert.Equal(0, _bolillero.BolillasFuera.Count);
    }

    [Fact]
    public void JugarGana()
    {
        var jugada = new List<int> { 0, 1, 2, 3 };

        Assert.True(_bolillero.Jugar(jugada));
    }

    [Fact]
    public void JugarPierde()
    {
        var jugada = new List<int> { 4, 2, 1 };

        Assert.False(_bolillero.Jugar(jugada));
    }

    [Fact]
    public void GanarNVeces()
    {
        var jugada = new List<int> { 0, 1 };

        var resultado = _bolillero.JugarNVeces(jugada, 1);

        Assert.Equal(1, resultado);
    }
}