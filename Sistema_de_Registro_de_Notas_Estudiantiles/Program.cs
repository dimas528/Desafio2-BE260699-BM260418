using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Registro_de_Notas_Estudiantiles
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //definimos variables
            int n = 0;
            bool valido;
            
            //pedimos el numero de estudiantes
            Console.WriteLine("Bienvenido al sistema de registro de notas");
            Console.WriteLine("Ingrese la cantidad de estudiantes");
            n = int.Parse(Console.ReadLine());

            //definimos vectores
            double[] notas = new double[n];
            string[] alumnos = new string[n];

            //metemos los datos a los vectores de manera paralela
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Ingrese el nombre del estudiante n°"+(i+1));
                alumnos[i] = Console.ReadLine();
                //validamos que el numero sea ingresado de manera correcta
                do {
                    double nota = 0;
                    Console.WriteLine("Ingrese la nota del estudiante n°" + (i + 1));
                    valido = double.TryParse(Console.ReadLine(), out nota);
                    if (!valido)
                    {
                        Console.WriteLine("Ingrese un numero valido");
                    }
                    else if(nota<0 || nota>10)
                    {
                        Console.WriteLine("Ingrese un numero valido");
                        valido = false;
                    }
                    else
                    {
                        notas[i] = nota;
                    }
                } while (!valido);
            }
            //evitamos que el programa se cierre solo 
            Console.ReadKey();
            
        }
        //creamos funciones para calcular el promedio, la nota mayor y menor 
        static double promedio(double[] vector) 
        {
            double suma=0;
            double avg = 0;
            for(int i = 0; i < vector.Length;i++) {
                suma = suma + vector[i];
            }
            avg = suma / vector.Length;
            return avg;
        }
        static double mayor(double[] vector)
        {
            double max = 0;
            max = vector[0];
            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] > max)
                {
                    max = vector[i];
                }
            }
            return max; 
        }
        static double menor(double[] vector)
        {
            double min = 0;
            min = vector[0];
            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] < min)
                {
                    min = vector[i];
                }
            }
            return min;
        }
        //creamos un procedimiento para ver si el estudiante aprobo
        static void paso(double[] v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] >= 6.0)
                {
                    Console.WriteLine("aprobo");
                }
                else
                {
                    Console.WriteLine("reprobo");
                }
            }
        } 
    }
}
