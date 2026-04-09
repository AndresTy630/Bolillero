namespace JuegoBolillero;

internal class GenerarAleatorio : IBolillero
{
    int IBolillero.GenerarAleatorio(int mini, int maxi)
    {
        Random r = new Random();
        var num = r.Next(mini, maxi);

        return num;
    }
}
