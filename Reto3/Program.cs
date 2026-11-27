// Reto 3. Tareas y tiempo

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // Descarga simulada que NO bloquea el hilo (await Task.Delay)
    static async Task Descargar(string nombre, int segundos)
    {
        Console.WriteLine($"  {nombre}: empiezo");
        await Task.Delay(segundos * 1000);
        Console.WriteLine($"  {nombre}: terminada");
    }

    // Descarga simulada que SÍ bloquea el hilo (Thread.Sleep)
    static Task DescargarConSleep(string nombre, int segundos)
    {
        Console.WriteLine($"  {nombre}: empiezo");
        Thread.Sleep(segundos * 1000);
        Console.WriteLine($"  {nombre}: terminada");
        return Task.CompletedTask;
    }

    static async Task Main()
    {
        Stopwatch reloj = Stopwatch.StartNew();

        Console.WriteLine("1) Una detrás de otra (Task.Delay):");
        await Descargar("Descarga 1", 1);
        await Descargar("Descarga 2", 2);
        await Descargar("Descarga 3", 3);
        Console.WriteLine($"Tiempo total: {reloj.Elapsed.TotalSeconds:F1} s");
        Console.WriteLine();

        reloj.Restart();
        Console.WriteLine("2) A la vez con Task.WhenAll (Task.Delay):");
        await Task.WhenAll(
            Descargar("Descarga 1", 1),
            Descargar("Descarga 2", 2),
            Descargar("Descarga 3", 3));
        Console.WriteLine($"Tiempo total: {reloj.Elapsed.TotalSeconds:F1} s");
        Console.WriteLine();

        reloj.Restart();
        Console.WriteLine("3) Task.WhenAll pero con Thread.Sleep:");
        await Task.WhenAll(
            DescargarConSleep("Descarga 1", 1),
            DescargarConSleep("Descarga 2", 2),
            DescargarConSleep("Descarga 3", 3));
        Console.WriteLine($"Tiempo total: {reloj.Elapsed.TotalSeconds:F1} s");
    }
}
