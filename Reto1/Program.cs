// Reto 1. Mi primer hilo
// Uso:  dotnet run                -> Join al final del programa
//       dotnet run -- join-ya     -> Join justo después de arrancar el hilo

using System.Threading;

class Program
{
    static void Contar()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Hilo: {i}  (id del hilo = {Environment.CurrentManagedThreadId})");
            Thread.Sleep(500); // medio segundo
        }
    }

    static void Main(string[] args)
    {
        bool joinYa = args.Length > 0 && args[0] == "join-ya";

        Console.WriteLine($"Main: arranco el hilo  (id de Main = {Environment.CurrentManagedThreadId})");
        Thread hilo = new Thread(Contar);
        hilo.Start();

        if (joinYa)
            hilo.Join(); // Main espera aquí a que el hilo termine

        Console.WriteLine($"Main: este es mi mensaje  (id de Main = {Environment.CurrentManagedThreadId})");

        if (!joinYa)
            hilo.Join(); // Main espera al final

        Console.WriteLine("Main: fin");
    }
}
