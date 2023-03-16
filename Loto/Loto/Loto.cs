using System;

namespace LotoClassNS
{
    // Clase que almacena una combinación de la lotería
    //
    public class LotoGP2223
    {
        // definición de constantes
        public const int MAXIMO_NUMEROS = 6;
        public const int NUMERO_MENOR = 1;
        public const int NUMERO_MAYOR = 49;

        private int[] _numeros = new int[MAXIMO_NUMEROS];   // numeros de la combinación
        public bool ok = false;      // combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)

        public int[] Numeros
        {
            get => _numeros;
            set => _numeros = value;
        }

        /// <summary>
        /// Constructor vacío que genera una combinación aleatoria correcta
        /// </summary>
        public LotoGP2223()
        {
            GenerarNumerosAleatorios();
        }

        

        // La segunda forma de crear una combinación es pasando el conjunto de números
        // misNumeros es un array de enteros con la combinación que quiero crear 
        /// <summary>
        /// Constructor con  parametro <paramref name="misNumeros"/>un <c>Array</c> de tipo enteros  
        /// </summary>
        ///<remarks>no tiene porqué ser válida</remarks>
        public LotoGP2223(int[] misNumeros)  // misnumeros: combinación con la que queremos inicializar la clase
        {
            for(int i = 0; i < MAXIMO_NUMEROS; i++)
                if(misNumeros[i] >= NUMERO_MENOR && misNumeros[i] <= NUMERO_MAYOR)
                {
                    int j;
                    for(j = 0; j < i; j++)
                        if(misNumeros[i] == Numeros[j])
                            break;
                    if(i == j)
                        Numeros[i] = misNumeros[i]; // validamos la combinación
                    else
                    {
                        ok = false;
                        return;
                    }
                }
                else
                {
                    ok = false;     // La combinación no es válida, terminamos
                    return;
                }
            ok = true;
        }

        // Método que comprueba el número de aciertos
        // premio es un array con la combinación ganadora
        // se devuelve el número de aciertos
        /// <summary>
        ///  Método que comprueba el número de aciertos
        /// </summary>
        /// <param name="premio"> Array con la combinación ganador</param>
        /// <returns>devuelve el número de aciertos</returns>
        public int Comprobar(int[] premio)
        {
            int numeroAciertos = 0;  
            
            for(int i = 0; i < MAXIMO_NUMEROS; i++)

                for(int j = 0; j < MAXIMO_NUMEROS; j++)

                    if(premio[i] == Numeros[j])

                        numeroAciertos++;

            return numeroAciertos;
        }
        private void GenerarNumerosAleatorios()
        {
            Random numerosAleatorios = new Random();    // clase generadora de números aleatorios

            int i = 0, j, numeros;

            do             // generamos la combinación
            {
                numeros = numerosAleatorios.Next(NUMERO_MENOR, NUMERO_MAYOR + 1);     // generamos un número aleatorio del 1 al 49
                for(j = 0; j < i; j++)    // comprobamos que el número no está
                    if(Numeros[j] == numeros)
                        break;
                if(i == j)               // Si i==j, el número no se ha encontrado en la lista, lo añadimos
                {
                    Numeros[i] = numeros;
                    i++;
                }
            } while(i < MAXIMO_NUMEROS);

            ok = true;
        }
    }

}
