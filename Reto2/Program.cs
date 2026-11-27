// Reto 2. Condición de carrera
// Uso:  dotnet run                -> 100.000 vueltas por hilo
//       dotnet run -- 1000000     -> 1.000.000 vueltas por hilo

using System.Threading;

class Program
{
    static int contador;
    static readonly object cerrojo = new object();
    static int vueltas = 100000;

    static void SumarSinProteccion()
    {
        for (int i = 0; i < vueltas; i++)
            contador++;
    }

    static void SumarConLock()
    {
        for (int i = 0; i < vueltas; i++)
            lock (cerrojo) { contador++; }
    }

    static void SumarConInterlocked()
    {
        for (int i = 0; i < vueltas; i++)
            Interlocked.Increment(ref contador);
    }

    // Lanza dos hilos con el método que le pasemos y devuelve el valor final
    static int Ejecutar(ThreadStart metodo)
    {
        contador = 0;
        Thread a = new Thread(metodo);
        Thread b = new Thread(metodo);
        a.Start();
        b.Start();
        a.Join();
        b.Join();
        return contador;
    }

    static void Probar(string titulo, ThreadStart metodo)
    {
        Console.WriteLine(titulo);
        for (int i = 1; i <= 5; i++)
            Console.WriteLine($"  Ejecución {i}: {Ejecutar(metodo)}");
    }

    static void Main(string[] args)
    {
        if (args.Length > 0)
            vueltas = int.Parse(args[0]);

        Console.WriteLine($"Cada hilo suma {vueltas} veces. Resultado correcto: {vueltas * 2}");
        Console.WriteLine();

        Probar("Sin protección:", SumarSinProteccion);
        Probar("Con lock:", SumarConLock);
        Probar("Con Interlocked.Increment:", SumarConInterlocked);
    }
}
