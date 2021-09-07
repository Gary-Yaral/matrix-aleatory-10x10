using System;

namespace MATRICES
{
    class Program
    {
        static void Main(string[] args)
        {
            Random numeroAleatorio = new Random();
            int numeroFilas = 10;
            int numeroColumnas = 10;
            int numeroCeldas = 10;
            int filaAleatoria;
            int columnaAleatoria;
            int[,] celdasAleatorias = ObtenerCeldasAleatorias(numeroCeldas, numeroAleatorio);
            int[,] matriz =  GenerarMatrizAleatoria(numeroFilas, numeroColumnas, numeroAleatorio);
            
            Console.Clear();
            //Título
            Console.Write("\n\t");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("MATRIZ ALEATORIA 10x10\n");
            Console.ResetColor();
            Console.Write("\n\tSelecciona 10 celdas al azar sin repetirse \n");
            Console.Write("\ty suma las celdas adjacentes \n");
            Console.WriteLine("\n\tDesarrollado por Gary Yaral\n");

            MostrarMatriz(matriz, celdasAleatorias);
            //Creamos un salto de línea
            Console.WriteLine("\n");

            for(int i = 0; i < numeroCeldas; i++){
                filaAleatoria = celdasAleatorias[i,0];
                columnaAleatoria = celdasAleatorias[i,1];
                int sumaCeldasAdjacentes = ObtenerSumaCeldas(matriz,filaAleatoria , columnaAleatoria);
                Console.WriteLine("\t" + (i + 1) + ". Elemento: " + matriz[filaAleatoria, columnaAleatoria]
                             + " ubicación: [" +  filaAleatoria + ", " +  columnaAleatoria 
                             + "] suma de adjacentes: " + sumaCeldasAdjacentes);   
            }
        }

        static int[,] ObtenerCeldasAleatorias(int numeroCeldas, Random numeroAleatorio){
            int[,] celdasSeleccionadas = new int[numeroCeldas, 2];
            int rangoInicial = 0;
            int rangoFinal = 9;
            int indice = 0;
            bool repetido;
            
            while(indice < numeroCeldas){
                repetido = false;
                int coordenadaX = numeroAleatorio.Next(rangoInicial, rangoFinal);
                int coordenadaY = numeroAleatorio.Next(rangoInicial, rangoFinal);

                for(int i = 0; i <= indice; i++){
                    if(celdasSeleccionadas[i,0] == coordenadaX && celdasSeleccionadas[i,1] == coordenadaY)
                    {
                         repetido = true;
                    }
                }

                if(!repetido)
                {   
                    celdasSeleccionadas[indice,0] = coordenadaX;
                    celdasSeleccionadas[indice,1] = coordenadaY;
                    indice++;
                }
                
            }

            return celdasSeleccionadas;
        }

        static int ObtenerSumaCeldas(int[,] Matriz, int filaAleatoria, int columnaAleatoria)
        {
           int sumaAdjacentes = 0;
           int LimiteX = Matriz.GetUpperBound(0);
           int LimiteY = Matriz.GetUpperBound(1);

           //Primera Fila
            if(filaAleatoria == 0)
            {
               //Primera columna
                if(columnaAleatoria == 0)
                {
                    sumaAdjacentes += Matriz[filaAleatoria, columnaAleatoria + 1];
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria];
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria + 1];
                }
                //Columnas centrales
                if(columnaAleatoria > 0 && columnaAleatoria < LimiteX)
                {
                    sumaAdjacentes += Matriz[filaAleatoria, columnaAleatoria - 1];
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria - 1];              
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria];
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria + 1];
                    sumaAdjacentes += Matriz[filaAleatoria, columnaAleatoria + 1];
                }

                //Última columna
                if(columnaAleatoria == LimiteX)
                {
                    sumaAdjacentes += Matriz[filaAleatoria, columnaAleatoria - 1];
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria - 1];              
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria];
                }
            }

            //Filas centrales
            if(filaAleatoria > 0 && filaAleatoria < LimiteY)
            {
               //Primera columna
                if(columnaAleatoria == 0)
                {
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria];
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria + 1];  
                    sumaAdjacentes += Matriz[filaAleatoria, columnaAleatoria + 1];
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria + 1];
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria];
                }
               
               //Columnas centrales 
                if(columnaAleatoria > 0 && columnaAleatoria < LimiteX )
                {
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria];
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria + 1];  
                    sumaAdjacentes += Matriz[filaAleatoria, columnaAleatoria + 1];
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria + 1];
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria];
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria - 1];
                    sumaAdjacentes += Matriz[filaAleatoria, columnaAleatoria - 1];
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria - 1];
                } 

               //Última columna 
                if(columnaAleatoria == LimiteX )
                {
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria];
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria - 1];  
                    sumaAdjacentes += Matriz[filaAleatoria, columnaAleatoria - 1];
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria - 1];
                    sumaAdjacentes += Matriz[filaAleatoria + 1, columnaAleatoria];
                } 
            }

            //Ultima Fila
            if(filaAleatoria == LimiteY)
            {
                 //Primera columna
                if(columnaAleatoria == 0){
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria];
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria + 1];
                    sumaAdjacentes += Matriz[filaAleatoria, columnaAleatoria + 1];
                }
                //Columnas centrales
                if(columnaAleatoria > 0 && columnaAleatoria < LimiteX)
                {
                    sumaAdjacentes += Matriz[filaAleatoria, columnaAleatoria - 1];
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria - 1];              
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria];
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria + 1];
                    sumaAdjacentes += Matriz[filaAleatoria, columnaAleatoria + 1];
                }

                //Ultima columna
                if(columnaAleatoria == LimiteX)
                {
                    sumaAdjacentes += Matriz[filaAleatoria, columnaAleatoria - 1];
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria - 1];              
                    sumaAdjacentes += Matriz[filaAleatoria - 1, columnaAleatoria];
                }

            }

            return sumaAdjacentes;
        }
        static int[,] GenerarMatrizAleatoria(int numeroFilas, int numeroColumnas, Random numeroAleatorio)
        {
            int[,] matriz = new int[numeroFilas, numeroColumnas];

            for (int i = 0; i < numeroFilas; i++)
            {
                for (int j = 0; j < numeroColumnas; j++)
                {
                    matriz[i, j] = numeroAleatorio.Next(1, 10);
                }
            }
            return matriz;
        }



        static void MostrarMatriz(int[,] matriz, int[,] celdasSeleccionadas)
        {
            for(int i = 0; i <= matriz.GetUpperBound(0); i++)
            {
                Console.Write("\t");
                for(int j = 0; j <= matriz.GetUpperBound(1); j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    for(int k = 0; k <= celdasSeleccionadas.GetUpperBound(0); k++)
                    {
                        
                        if(i == celdasSeleccionadas[k,0] && j == celdasSeleccionadas[k,1])
                        {
                            //Si esta seleccionada se pinta
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }              
                    }

                    Console.Write(" "+matriz[i,j]+" ");
                    Console.ResetColor();                   
                }

                Console.Write("\n");
            }

        }
    }
}