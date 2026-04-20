namespace JuegoBolillero;

internal class GenerarAleatorio : IBolillero
{
    private readonly Random _random = new Random();

    int IBolillero.GenerarAleatorio(int mini, int maxi)
    {
        return _random.Next(mini, maxi);
    }
}