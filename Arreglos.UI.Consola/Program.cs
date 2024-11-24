using Arreglos.Logica;
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
                        Console.WriteLine(miArreglo + "\n");

                        break;

                    case 3:
                        Console.WriteLine("Mostrar Pares del arreglo:  \n");
                        miArreglo.ObtenerPares();
                        var verPares = miArreglo.ObtenerPares();
                        verPares.Ordenar(true);
                        Console.WriteLine(verPares + "\n");
                        break;
                    case 4:
                        Console.WriteLine("Mostrar Impares del arreglo; \n");
                        miArreglo.ObtenerPrimos();
                        var verPrimos = miArreglo.ObtenerPrimos();
                        Console.WriteLine(verPrimos + "\n");
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
            Console.WriteLine("1. Definir el arreglo");
            Console.WriteLine("2. Mostrar arreglo");
            Console.WriteLine("3. Mostrar numeros pares");
            Console.WriteLine("4. Mostrar numeros primos");
            Console.WriteLine("5. Mostrar numeros que no se repitren");
            Console.WriteLine("6. Mostrar numeros que mas se repiten");
            Console.WriteLine("0. Salir");

            bool EsValido = false;

            int op = 0;
            //Validar si la opcion del usuario es correcta//
            do
            {
                Console.WriteLine("\n Seleccione una opcion del menu: ");
                var opCadena = Console.ReadLine();

                if (!int.TryParse(opCadena, out op) || op < 0 || op > 7)
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



        //Console.WriteLine("Programa de arreglos");

        //MiArreglo miArreglo = new(10);

        ////Inicia Arreglos del reporte de practica anterior
        //miArreglo.Llenar(-5, 20);


        //Console.WriteLine("Arreglo desordenado\n");
        //Console.WriteLine(miArreglo);

        //Console.WriteLine("Arreglo ordenado asendente sin decidir\n");
        //miArreglo.Ordenar();
        //Console.WriteLine(miArreglo);

        //Console.WriteLine("Arreglo ordenado asendente \n");
        //miArreglo.Ordenar(true);
        //Console.WriteLine(miArreglo);

        //Console.WriteLine("Arreglo ordenado desendente\n");
        //miArreglo.Ordenar(false);
        //Console.WriteLine(miArreglo);

        //Console.WriteLine("---------------");
        ////Finaliza arreglos reporte anterior


        //miArreglo.Llenar();
        //Console.WriteLine(miArreglo);

        //Console.WriteLine("\n Pares\n");
        //var verPares = miArreglo.ObtenerPares();
        //Console.WriteLine(verPares);

        //Console.WriteLine("\n Pares ordenados ascendentemente\n");
        //verPares.Ordenar(true);
        //Console.WriteLine(verPares);



        //Console.WriteLine("\n Primos \n");
        //var tiempo1 = DateTime.Now;
        //var verPrimos = miArreglo.ObtenerPrimos();
        //var tiempo2 = DateTime.Now;
        //var restarTiempo = tiempo2 - tiempo1;
        //Console.WriteLine(verPrimos);

        //Console.WriteLine($"\n Tiempo transcurrido: {restarTiempo.Minutes} minutos " +
        //    $"{restarTiempo.Seconds} segundos, " +
        //    $"{restarTiempo.Milliseconds} MIilisegundos \n");


        //Console.WriteLine("---------------");
        //Console.WriteLine("Jose Sebastian Rodriguez Salgado\n");
        //Console.WriteLine("Programa de Arreglo B y C\n");

        //Console.WriteLine("Arreglo B generado: \n");
        //MiArreglo arregloB = new MiArreglo(0);
        //arregloB = arregloB.LlenadoArregloB();

        //Console.WriteLine("Arreglo C generado: \n");
        //MiArreglo arregloC = arregloB.GenerarArregloC();
        //Console.WriteLine(arregloC);

        //Console.WriteLine("---------------");

        //miArreglo.ObtenerPares();
        //var verPares = miArreglo.ObtenerPares();
        //Console.WriteLine(verPares);
        //try //funciona para controlar una excepcion en este caso si se supera el limite muestra mensaje
        //{

        //    miArreglo.Insertar(8, 0);
        //    miArreglo.Insertar(3, 1);
        //    miArreglo.Insertar(9, 2);
        //    miArreglo.Insertar(5, 3);
        //    miArreglo.Insertar(6, 4);
        //    Console.WriteLine(miArreglo);
        //    Console.WriteLine("-------------------");

        //    miArreglo.Eliminar(1);


        //Console.WriteLine(miArreglo);

        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);

        //}




        Console.ReadKey();
    }
}