using Arreglos.Logica;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Tercer semestre - Estructura de datos");
        Console.WriteLine("Nombre del Alumno: Jose Sebastian Rodriguez Salgado");

        try
        {
            int opcion;
            MiArreglo miArreglo = new(10);

            do
            {
                opcion = menu();
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el tamaño del arreglo: ");
                        var nString = Console.ReadLine();
                        int n = 10;
                        int.TryParse(nString, out n);
                        miArreglo = new MiArreglo(n);
                        miArreglo.Llenar();
                        break;

                    case 2:
                        Console.WriteLine("Mostrar Arreglo Generado: \n");
                        Console.WriteLine("----------------------------");
                        Console.WriteLine(miArreglo + "\n");
                        Console.WriteLine("----------------------------");
                        break;

                    case 3:
                        Console.WriteLine("Mostrar Pares del arreglo:  \n");
                        Console.WriteLine($"Arreglo Original: {miArreglo}");
                        miArreglo.ObtenerPares();
                        var verPares = miArreglo.ObtenerPares();
                        verPares.Ordenar(true);
                        Console.WriteLine("Arreglo Resultante: " + verPares);
                        Console.WriteLine("----------------------------");
                        break;

                    case 4:
                        Console.WriteLine("Mostrar Impares del arreglo; \n");
                        Console.WriteLine($"Arreglo Original: {miArreglo}");
                        miArreglo.ObtenerPrimos();
                        var verPrimos = miArreglo.ObtenerPrimos();
                        Console.WriteLine("Arreglo Resultante: " + verPrimos);
                        Console.WriteLine("----------------------------");
                        break;

                    case 5:
                        Console.WriteLine("Mostrar números que no se repiten; \n");
                        var unicos = miArreglo.ObtenerUnicos();
                        Console.WriteLine($"Arreglo Original: {miArreglo}");
                        Console.WriteLine("Arreglo Resultante: " + unicos);
                        Console.WriteLine("----------------------------");
                        break;

                    case 6:
                        Console.WriteLine("Mostrar números que más se repiten; \n");
                        var frecuentes = miArreglo.ObtenerMasFrecuentes();
                        Console.WriteLine($"Arreglo Original: {miArreglo}");
                        Console.WriteLine("Arreglo Resultante: " + frecuentes);
                        Console.WriteLine("----------------------------");
                        break;

                    case 7:
                        Console.WriteLine("Mostrar Ordenación por Burbuja.; \n");
                        var swBurbuja = Stopwatch.StartNew();
                        Console.WriteLine($"Arreglo Original: {miArreglo}");
                        miArreglo.Ordenar();
                        swBurbuja.Stop();
                        Console.WriteLine("Arreglo Resultante:\n" + miArreglo);
                        Console.WriteLine($"Tiempo: {FormatoTiempo(swBurbuja.Elapsed)}");
                        Console.WriteLine("----------------------------");
                        break;

                    case 8:
                        Console.WriteLine("Mostrar Ordenación por Inserción.; \n");
                        var swInsercion = Stopwatch.StartNew();
                        Console.WriteLine($"Arreglo Original: {miArreglo}");
                        miArreglo.OrdenarInsercion();
                        swInsercion.Stop();
                        Console.WriteLine("Arreglo Resultante:\n" + miArreglo);
                        Console.WriteLine($"Tiempo: {FormatoTiempo(swInsercion.Elapsed)}");
                        Console.WriteLine("----------------------------");
                        break;

                    case 9:
                        Console.WriteLine("Mostrar Ordenación por Selección.; \n");
                        var swSeleccion = Stopwatch.StartNew();
                        Console.WriteLine($"Arreglo Original: {miArreglo}");
                        miArreglo.OrdenarSeleccion();
                        swSeleccion.Stop();
                        Console.WriteLine("Arreglo Resultante:\n" + miArreglo);
                        Console.WriteLine($"Tiempo: {FormatoTiempo(swSeleccion.Elapsed)}");
                        Console.WriteLine("----------------------------");
                        break;
                    case 10:
                        Console.WriteLine("Ordenar por Shell:");
                        var swShell = Stopwatch.StartNew();
                        Console.WriteLine($"Arreglo Original: {miArreglo}");
                        miArreglo.OrdenarShell();
                        swShell.Stop();
                        Console.WriteLine("Arreglo Resultante:\n" + miArreglo);
                        Console.WriteLine($"Tiempo: {FormatoTiempo(swShell.Elapsed)}");
                        Console.WriteLine("----------------------------");
                        break;

                    case 11:
                        Console.WriteLine("Mostrar Ordenación por Quicksort; \n");
                        var swQuickSort = Stopwatch.StartNew();
                        Console.WriteLine($"Arreglo Original: {miArreglo}");
                        miArreglo.OrdenarQuickSort();
                        swQuickSort.Stop();
                        Console.WriteLine("Arreglo Resultante:\n" + miArreglo);
                        Console.WriteLine($"Tiempo: {FormatoTiempo(swQuickSort.Elapsed)}");
                        Console.WriteLine("----------------------------");
                        break;

                    case 12:
                        Console.WriteLine("Mostrar Búsqueda Secuencial.; \n");
                        var valorSec = int.Parse(Console.ReadLine());
                        var indexSec = miArreglo.BusquedaSecuencial(valorSec);
                        Console.WriteLine("----------------------------");
                        Console.WriteLine(indexSec != -1
                            ? $"Valor encontrado en el índice: {indexSec}"
                            : "Valor no encontrado.");
                        Console.WriteLine("----------------------------");
                        break;

                    case 13:
                        Console.WriteLine("Mostrar Búsqueda Binaria.; \n");
                        var valorBin = int.Parse(Console.ReadLine());
                        var indexBin = miArreglo.BusquedaBinaria(valorBin);
                        Console.WriteLine("----------------------------");
                        Console.WriteLine(indexBin != -1
                            ? $"Valor encontrado en el índice: {indexBin}"
                            : "Valor no encontrado.");
                        Console.WriteLine("----------------------------");
                        break;

                    case 0:
                        Console.WriteLine("¡Programa terminado!");
                        break;
                }

            } while (opcion != 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static int menu()
    {
        // Menú de opciones
        Console.WriteLine("1. Definir el tamaño del arreglo.");
        Console.WriteLine("2. Mostrar arreglo.");
        Console.WriteLine("3. Mostrar números pares.");
        Console.WriteLine("4. Mostrar números primos.");
        Console.WriteLine("5. Mostrar números que no se repiten.");
        Console.WriteLine("6. Mostrar números que más se repiten.");
        Console.WriteLine("7. Ordenación por Burbuja.");
        Console.WriteLine("8. Ordenación por Inserción.");
        Console.WriteLine("9. Ordenación por Selección.");
        Console.WriteLine("10. Ordenación por Shell.");
        Console.WriteLine("11. Ordenación por Quicksort.");
        Console.WriteLine("12. Búsqueda Secuencial.");
        Console.WriteLine("13. Búsqueda Binaria.");
        Console.WriteLine("0. Salir");

        int op = 0;
        do
        {
            Console.WriteLine("\n Seleccione una opción del menú: ");
            var opCadena = Console.ReadLine();
            if (!int.TryParse(opCadena, out op) || op < 0 || op > 13)
            {
                Console.WriteLine("\n Selecciona una opción válida.");
            }
        } while (op < 0 || op > 13);

        return op;
    }

    private static string FormatoTiempo(TimeSpan tiempo)
    {
        return $"{tiempo.Hours}h:{tiempo.Minutes}m:{tiempo.Seconds}s:{tiempo.Milliseconds}ms";
    }
}


