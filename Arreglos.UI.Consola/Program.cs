using Arreglos.Logica;
using System.Diagnostics;
internal class Program
{
    private static void Main(string[] args)
    {
        //PINTAR MENU//
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
                        miArreglo = new(n);
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
                        miArreglo.ObtenerPares();
                        var verPares = miArreglo.ObtenerPares();
                        verPares.Ordenar(true);
                        Console.WriteLine("----------------------------");
                        Console.WriteLine(verPares + "\n");
                        Console.WriteLine("----------------------------");
                        break;

                    case 4:
                        Console.WriteLine("Mostrar Impares del arreglo; \n");
                        miArreglo.ObtenerPrimos();
                        var verPrimos = miArreglo.ObtenerPrimos();
                        Console.WriteLine("----------------------------");
                        Console.WriteLine(verPrimos + "\n");
                        Console.WriteLine("----------------------------");
                        break;

                    case 5:
                        Console.WriteLine("Mostrar números que no se repiten; \n");
                        var unicos = miArreglo.ObtenerUnicos(); // Método por implementar
                        Console.WriteLine("----------------------------");
                        Console.WriteLine(unicos);
                        Console.WriteLine("----------------------------");
                        break;

                    case 6:
                        Console.WriteLine("Mostrar números que mas se repiten; \n");
                        var frecuentes = miArreglo.ObtenerMasFrecuentes(); // Método por implementar
                        Console.WriteLine("----------------------------");
                        Console.WriteLine(frecuentes);
                        Console.WriteLine("----------------------------");
                        break;

                    case 7:
                        Console.WriteLine("Mostrar Ordenación por Burbuja.; \n");
                        var swBurbuja = Stopwatch.StartNew();
                        miArreglo.Ordenar(); // Implementado como método por defecto en `MiArreglo`
                        swBurbuja.Stop();
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Arreglo ordenado:\n" + miArreglo);
                        Console.WriteLine($"Tiempo: {FormatoTiempo(swBurbuja.Elapsed)}");
                        Console.WriteLine("----------------------------");
                        break;

                    case 8:
                        Console.WriteLine("Mostrar Ordenación por Inserción.; \n");
                        var swInsercion = Stopwatch.StartNew();
                        miArreglo.OrdenarInsercion(); // Método por implementar en `MiArreglo`
                        swInsercion.Stop();
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Arreglo ordenado:\n" + miArreglo);
                        Console.WriteLine($"Tiempo: {FormatoTiempo(swInsercion.Elapsed)}");
                        Console.WriteLine("----------------------------");
                        break;

                    case 9:
                        Console.WriteLine("Mostrar  Ordenación por Selección.; \n");
                        var swSeleccion = Stopwatch.StartNew();
                        miArreglo.OrdenarSeleccion(); // Método por implementar en `MiArreglo`
                        swSeleccion.Stop();
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Arreglo ordenado:\n" + miArreglo);
                        Console.WriteLine($"Tiempo: {FormatoTiempo(swSeleccion.Elapsed)}");
                        Console.WriteLine("----------------------------");
                        break;
                    case 10:
                        Console.WriteLine("Ordenar por Shell:");
                        var swShell = Stopwatch.StartNew();
                        miArreglo.OrdenarShell(); // Método por implementar en `MiArreglo`
                        swShell.Stop();
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Arreglo ordenado:\n" + miArreglo);
                        Console.WriteLine($"Tiempo: {FormatoTiempo(swShell.Elapsed)}");
                        Console.WriteLine("----------------------------");
                        break;

                    case 11:
                        Console.WriteLine("Mostrar Ordenación por Quicksort; \n");
                        var swQuickSort = Stopwatch.StartNew();
                        miArreglo.OrdenarQuickSort(); // Método por implementar en `MiArreglo`
                        swQuickSort.Stop();
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("Arreglo ordenado:\n" + miArreglo);
                        Console.WriteLine($"Tiempo: {FormatoTiempo(swQuickSort.Elapsed)}");
                        Console.WriteLine("----------------------------");
                        break;

                    case 12:
                        Console.WriteLine("Mostrar Búsqueda Secuencial.; \n");
                        var valorSec = int.Parse(Console.ReadLine());
                        var indexSec = miArreglo.BusquedaSecuencial(valorSec); // Método por implementar
                        Console.WriteLine("----------------------------");
                        Console.WriteLine(indexSec != -1
                            ? $"Valor encontrado en el índice: {indexSec}"
                            : "Valor no encontrado.");
                        Console.WriteLine("----------------------------");
                        break;

                    case 13:
                        Console.WriteLine("Mostrar Búsqueda Binaria.; \n");
                        var valorBin = int.Parse(Console.ReadLine());
                        var indexBin = miArreglo.BusquedaBinaria(valorBin); // Método por implementar
                        Console.WriteLine("----------------------------");
                        Console.WriteLine(indexBin != -1
                            ? $"Valor encontrado en el índice: {indexBin}"
                            : "Valor no encontrado.");
                        Console.WriteLine("----------------------------");
                        break;
                }

            } while (opcion != 0);
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

        int menu()
        {
            //Pintar menu//
            Console.WriteLine("1. Definir el arreglo.");
            Console.WriteLine("2. Mostrar arreglo.");
            Console.WriteLine("3. Mostrar numeros pares.");
            Console.WriteLine("4. Mostrar numeros primos.");
            Console.WriteLine("5. Mostrar numeros que no se repitren.");
            Console.WriteLine("6. Mostrar numeros que mas se repiten.");
            Console.WriteLine("7. Ordenación por Burbuja.");
            Console.WriteLine("8. Ordenación por Inserción.");
            Console.WriteLine("9. Ordenación por Selección.8");
            Console.WriteLine("10. Ordenación por Shell.");
            Console.WriteLine("11. Ordenación por Quicksort.");
            Console.WriteLine("12. Búsqueda Secuencial.");
            Console.WriteLine("13. Búsqueda Binaria.");
            Console.WriteLine("0. Salir");

            bool EsValido = false;

            int op = 0;

            //Validar si la opcion del usuario es correcta//
            do
            {
                Console.WriteLine("\n Seleccione una opcion del menu: ");
                var opCadena = Console.ReadLine();

                if (!int.TryParse(opCadena, out op) || op < 0 || op > 13)
                {
                    Console.WriteLine("\n Selecciona una opción correcta, use solo numeros");
                    EsValido = false;
                }
                else
                {
                    EsValido = true;
                }

            } while (EsValido == false);

            return op;


        }

        private static string FormatoTiempo(TimeSpan tiempo)
        {
            return $"{tiempo.Hours}h:{tiempo.Minutes}m:{tiempo.Seconds}s:{tiempo.Milliseconds}ms";
        }

        Console.ReadKey();
    }
}