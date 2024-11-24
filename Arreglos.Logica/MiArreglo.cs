﻿namespace Arreglos.Logica
{
    public class MiArreglo
    {
        //Campos o stributo
        private int _tope;
        private int[] _arreglo;

        //Constructor
        public MiArreglo(int n)
        {
            N = n;
            _arreglo = new int[N];
            _tope = 0;
        }

        //Propiedades 
        public int N { get; }
        public bool EstaLLeno => _tope == N;
        public bool EstaVacio => _tope == 0;

        //Metodos
        //---------------------------------------------------------------
        //public MiArreglo LlenadoArregloB()
        //{
        //    Console.WriteLine("Ingresa el tamaño del arreglo B: \n");
        //    int tamB = Convert.ToInt32(Console.ReadLine());

        //    MiArreglo arregloB = new MiArreglo(tamB);
        //    arregloB.Llenar(1, 20);

        //    Console.WriteLine("Arreglo B generado con random es: \n");
        //    Console.WriteLine(arregloB);

        //    return arregloB;
        //}

        //public MiArreglo GenerarArregloC()
        //{
        //    MiArreglo valoresUn = ObtenerVUnicos();
        //    MiArreglo arregloC = new MiArreglo(valoresUn._tope * 2);

        //    LlenarArregloC(arregloC, valoresUn, 0);

        //    return arregloC;
        //}

        //private void LlenarArregloC(MiArreglo arregloC, MiArreglo valoresUn, int i)
        //{
        //    if (i >= valoresUn._tope) return;

        //    arregloC.Agregar(valoresUn._arreglo[i]);

        //    int repeticiones = ContarRep(_arreglo, _tope, valoresUn._arreglo[i], 0);
        //    arregloC.Agregar(repeticiones);

        //    LlenarArregloC(arregloC, valoresUn, i + 1);
        //}

        //private int ContarRep(int[] arreglo, int tamano, int valor, int i)
        //{
        //    if (i >= tamano) return 0;
        //    return (arreglo[i] == valor ? 1 : 0) + ContarRep(arreglo, tamano, valor, i + 1);
        //}

        //private MiArreglo ObtenerVUnicos()
        //{
        //    MiArreglo valoresU = new MiArreglo(_tope);

        //    for (int i = 0; i < _tope; i++)
        //    {
        //        if (!valoresU.Contiene(_arreglo[i]))
        //        {
        //            valoresU.Agregar(_arreglo[i]);
        //        }
        //    }

        //    return valoresU;
        //}

        //private bool Contiene(int valor)
        //{
        //    for (int i = 0; i < _tope; i++)
        //    {
        //        if (_arreglo[i] == valor) return true;
        //    }
        //    return false;
        //}
        //-------------------------------------------------------------

        public MiArreglo ObtenerPares()
        {
            int contadorPares = 0;

            for (int i = 0; i < _tope; i++)
            {
                if (_arreglo[i] % 2 == 0)
                {

                    contadorPares++;
                }

            }

            var arregloPares = new MiArreglo(contadorPares);

            for (int i = 0; i < _tope; i++)
            {
                if (_arreglo[i] % 2 == 0)
                {

                    arregloPares.Agregar(_arreglo[i]);
                }
            }
            return arregloPares;

        }

        public MiArreglo ObtenerPrimos()
        {
            int contadorPrimos = 0;
            for (int i = 0; i < _tope; i++)
            {
                if (EsPrimo(_arreglo[i]))
                {
                    contadorPrimos++;
                }

            }
            var arregloPrimos = new MiArreglo(contadorPrimos);
            for (int i = 0; i < _tope; i++)
            {
                if (EsPrimo(_arreglo[i]))
                {
                    arregloPrimos.Agregar(_arreglo[i]);
                }
            }
            return arregloPrimos;
        }

        private bool EsPrimo(int numero)
        {
            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                {
                    return false;

                }
            }
            return true;

        }


        public void Llenar()
        {
            Llenar(1, 100);
        }

        public void Llenar(int minimo, int maximo)
        {
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                _arreglo[i] = random.Next(minimo, maximo);
            }

            _tope = N;

        }

        public void Ordenar() //metodo burbuja
        {

            Ordenar(true);
        }
        public void Ordenar(bool asendente)
        {
            for (int i = 0; i < _tope - 1; i++)
            {
                for (int j = i + 1; j < _tope; j++)
                {
                    if (asendente)
                    {
                        if (_arreglo[i] < _arreglo[j])
                        {
                            Cambiar(ref _arreglo[i], ref _arreglo[j]);
                        }

                    }
                    else
                    {
                        if (_arreglo[i] > _arreglo[j])
                        {
                            Cambiar(ref _arreglo[i], ref _arreglo[j]);
                        }
                    }
                }

            }
        }

        private void Cambiar(ref int a, ref int b)
        {
            int aux = b;
            b = a;
            a = aux;
        }
        public void Agregar(int numero)
        {
            if (EstaLLeno)
            {
                throw new Exception("El arreglo esta lleno");   //Lanza una excepcion si el arreglo esta lleno
            }

            _arreglo[_tope] = numero;
            _tope++;

        }

        public void Insertar(int numero, int posicion)
        {
            if (EstaLLeno)
            {
                throw new Exception("El arreglo esta lleno");
            }

            if (posicion < 0)
            {
                posicion = 0;
            }
            if (posicion > _tope)
            {
                posicion = _tope;

            }

            for (int i = _tope; i > posicion; i--)

            {
                _arreglo[i] = _arreglo[i - 1];


            }

            _arreglo[posicion] = numero;
            _tope++;
        }

        public void Eliminar(int posicion)
        {
            if (EstaVacio)
            {
                throw new Exception("El arreglo esta vacio");
            }
            if (posicion < 0)
            {
                posicion = 0;
            }

            if (posicion > _tope)
            {
                posicion = _tope;
            }
            for (int i = posicion; i < _tope; i++)
            {
                _arreglo[i] = _arreglo[i + 1];
            }
            _tope--;

        }




        public override string ToString()
        {
            string salida = string.Empty;

            if (EstaVacio)
            {
                return "El arreglo esta vacio";
            }
            int contador = 0;
            for (int i = 0; i < _tope; i++)
            {
                salida += $"{_arreglo[i]}\t";
                contador++;

                if (contador > 9)
                {
                    salida += "\n";
                    contador = 0;
                }

            }
            return salida;
        }

    }
}