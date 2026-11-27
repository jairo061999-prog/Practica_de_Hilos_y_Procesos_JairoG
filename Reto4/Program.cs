// Reto 4. Lanzar un proceso

using System.Diagnostics;

class Program
{
    static void Ejecutar(string programa, string argumentos)
    {
        Console.WriteLine($"Lanzo: {programa} {argumentos}");
        try
        {
            ProcessStartInfo info = new ProcessStartInfo(programa, argumentos)
            {
                RedirectStandardOutput = true, // para capturar lo que escribe
                UseShellExecute = false
            };

            using Process p = Process.Start(info);
            string salida = p.StandardOutput.ReadToEnd();
            p.WaitForExit(); // esperamos a que termine

            Console.WriteLine($"Salida: {salida.Trim()}");
            Console.WriteLine($"ExitCode: {p.ExitCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"No se ha podido lanzar el programa: {ex.Message}");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Ejecutar("dotnet", "--version");           // existe: todo va bien
        Ejecutar("programa_que_no_existe", "");    // no existe: da error
    }
}
