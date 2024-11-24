namespace Arreglos.Logica
{
    public class MiArreglo
    {
        // Campos o atributo
        private int _tope;
        private int[] _arreglo;

        // Constructor
        public MiArreglo(int n)
        {
            N = n;
            _arreglo = new int[N];
            _tope = 0;
        }

        // Propiedades
        public int N { get; }
        public bool EstaLLeno => _tope == N;
        public bool EstaVacio => _tope == 0;
        public bool EstaOrdenado { get; private set; } = false;

        // Métodos de llenado y manipulación del arreglo
        public void Llenar()
        {
            Llenar(1, 100); // Por defecto llena con números entre 1 y 100
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

        // Métodos de obtención solicitados
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

        public MiArreglo ObtenerUnicos()
        {
            var unicos = new MiArreglo(_tope);
            var contador = new Dictionary<int, int>();

            for (int i = 0; i < _tope; i++)
            {
                if (contador.ContainsKey(_arreglo[i]))
                    contador[_arreglo[i]]++;
                else
                    contador[_arreglo[i]] = 1;
            }

            foreach (var item in contador)
            {
                if (item.Value == 1)
                    unicos.Agregar(item.Key);
            }

            return unicos;
        }

        public MiArreglo ObtenerMasFrecuentes()
        {
            var frecuentes = new MiArreglo(_tope);
            var contador = new Dictionary<int, int>();

            for (int i = 0; i < _tope; i++)
            {
                if (contador.ContainsKey(_arreglo[i]))
                    contador[_arreglo[i]]++;
                else
                    contador[_arreglo[i]] = 1;
            }

            int maxFrecuencia = contador.Values.Max();

            foreach (var item in contador)
            {
                if (item.Value == maxFrecuencia)
                    frecuentes.Agregar(item.Key);
            }

            return frecuentes;
        }

        //----------------------------------------------------
        // Métodos de ordenamiento solicitados en la asignación
        //---------------------------------------------------

        public void Ordenar()
        {
            Ordenar(true); // Método burbuja por defecto
        }

        public void Ordenar(bool ascendente)
        {
            for (int i = 0; i < _tope - 1; i++)
            {
                for (int j = i + 1; j < _tope; j++)
                {
                    if (ascendente)
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
            EstaOrdenado = true;
        }

        // Ordenación por Inserción.
        public void OrdenarInsercion()
        {
            for (int i = 1; i < _tope; i++)
            {
                int aux = _arreglo[i];
                int j = i - 1;

                while (j >= 0 && _arreglo[j] > aux)
                {
                    _arreglo[j + 1] = _arreglo[j];
                    j--;
                }

                _arreglo[j + 1] = aux;
            }
            EstaOrdenado = true;
        }

        // Ordenación por Selección.
        public void OrdenarSeleccion()
        {
            for (int i = 0; i < _tope - 1; i++)
            {
                int indiceMenor = i;
                for (int j = i + 1; j < _tope; j++)
                {
                    if (_arreglo[j] < _arreglo[indiceMenor])
                    {
                        indiceMenor = j;
                    }
                }
                if (i != indiceMenor)
                {
                    Cambiar(ref _arreglo[i], ref _arreglo[indiceMenor]);
                }
            }
            EstaOrdenado = true;
        }

        // Ordenación por Shell.
        public void OrdenarShell()
        {
            int intervalo = _tope / 2;
            while (intervalo > 0)
            {
                for (int i = intervalo; i < _tope; i++)
                {
                    int temp = _arreglo[i];
                    int j = i;

                    while (j >= intervalo && _arreglo[j - intervalo] > temp)
                    {
                        _arreglo[j] = _arreglo[j - intervalo];
                        j -= intervalo;
                    }

                    _arreglo[j] = temp;
                }

                intervalo /= 2;
            }
            EstaOrdenado = true;
        }

        // Ordenación por Quicksort.
        public void OrdenarQuickSort()
        {
            QuickSort(0, _tope - 1);
            EstaOrdenado = true;
        }

        private void QuickSort(int inicio, int fin)
        {
            if (inicio >= fin)
                return;

            int pivote = _arreglo[inicio];
            int izquierda = inicio + 1;
            int derecha = fin;

            while (izquierda <= derecha)
            {
                while (izquierda <= fin && _arreglo[izquierda] <= pivote) izquierda++;
                while (derecha > inicio && _arreglo[derecha] > pivote) derecha--;

                if (izquierda < derecha)
                {
                    Cambiar(ref _arreglo[izquierda], ref _arreglo[derecha]);
                }
            }

            Cambiar(ref _arreglo[inicio], ref _arreglo[derecha]);

            QuickSort(inicio, derecha - 1);
            QuickSort(derecha + 1, fin);
        }

        //--------------------------------------------
        // Métodos de búsqueda solicitados en la asignación
        //--------------------------------------------

        public int BusquedaSecuencial(int valor)
        {
            for (int i = 0; i < _tope; i++)
            {
                if (_arreglo[i] == valor)
                    return i; // Valor encontrado
            }
            return -1; // No encontrado
        }

        public int BusquedaBinaria(int valor)
        {
            if (!EstaOrdenado)
                throw new Exception("El arreglo debe estar ordenado para realizar una búsqueda binaria.");

            int izquierda = 0, derecha = _tope - 1;

            while (izquierda <= derecha)
            {
                int medio = (izquierda + derecha) / 2;

                if (_arreglo[medio] == valor)
                    return medio; // Valor encontrado
                if (_arreglo[medio] < valor)
                    izquierda = medio + 1;
                else
                    derecha = medio - 1;
            }

            return -1; // No encontrado
        }

        //----------------------------------------------

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
                throw new Exception("El arreglo está lleno");
            }

            _arreglo[_tope] = numero;
            _tope++;
        }

        public override string ToString()
        {
            string salida = string.Empty;

            if (EstaVacio)
            {
                return "El arreglo está vacío";
            }

            for (int i = 0; i < _tope; i++)
            {
                salida += $"{_arreglo[i]}\t";
            }

            return salida;
        }
    }
}







