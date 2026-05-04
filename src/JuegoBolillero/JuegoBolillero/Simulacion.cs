using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoBolillero
{
    internal class Simulacion
    {
        public static long SimularSinHilos(Bolillero bolillero, List<int> jugada, int cantidad)
        {
            var clon = bolillero.Clonar() as Bolillero;

            return clon.JugarNVeces(jugada, cantidad);
        }

        public static long SimularConHilos(Bolillero bolillero, List<int> jugada, int cantSim, int cantHilos)
        {
            long ganadas = 0;

            int simularPorHilo = cantSim / cantHilos;

            Task<long>[] tareas = new Task<long>[cantHilos];

            for (int i = 0; i < cantHilos; i++)
            {

                tareas[i] = Task.Run(() =>
                {
                    var clon = bolillero.Clonar() as Bolillero;
                    return SimularSinHilos(clon, jugada, simularPorHilo);
                });
            }

            Task.WaitAll(tareas);

            foreach (Task<long> tarea in tareas)
                ganadas += tarea.Result;

            return ganadas;
        }
    }
}
