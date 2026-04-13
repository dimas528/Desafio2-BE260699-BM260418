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
            int reprobados=0;
            int aprobados = 0;
            //pedimos el numero de estudiantes
            Console.WriteLine("Bienvenido al sistema de registro de notas:");
            Console.WriteLine("Ingrese la cantidad de estudiantes:");
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
            Console.Clear();
            //mostramos el informe para cada estudiante
            Console.WriteLine("Reporte Academico");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n");
                Console.WriteLine($"Estudiante: {alumnos[i]}");
                Console.WriteLine($"Tu nota es: {notas[i]}");
                Console.WriteLine($"La cual refiere en formato alfabetico a: {letras(notas[i])}");
                
                Console.WriteLine($"Tu estado academico es: {paso(notas[i]) }");
                Console.WriteLine("----------------------");
                Console.WriteLine("\n");

            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Resumen Final");
            for(int i = 0; i < n; i++)
            {
                if (notas[i] < 6)
                {
                    reprobados += 1;
                }
                if (notas[i] >= 6)
                {
                    aprobados += 1;
                }
            }
            Console.WriteLine("Total aprobados: "+ aprobados);
            Console.WriteLine("Total reprobados: " + reprobados);
            Console.WriteLine("Promedio general: " + promedio(notas));
            Console.WriteLine("Nota mayor: " + mayor(notas));
            Console.WriteLine("Nota menor: " + menor(notas));

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
        //pasomos el procedimeinto a funcion; funcion para ver si el estudiante aprobo
        static string paso(double v)
        {
                if (v >= 6.0)
                {
                    string estado = "aprobado";
                    return estado;
                }
                else
                {
                    string estado = "reprobado";
                    return estado;
            }
            
        }
        //pasomos el procedimeinto a funcion; funcion para pasar notas de numeros a letras
        static string letras(double v)
        {
            
                //A=9-10, B=8-8.9, C=7-7.9, D=6-6.9, F=0-5.9
                if (v>=9)
                {
                return "A";
                }
                else if(v >= 8 && v<9)
                {
                return "B";
                }
                else if (v >= 7 && v < 8)
                {
                return "C";
                }
                else if (v >= 6 && v < 7)
                {
                return "D";
                }
                else if (v>= 0 && v < 6)
                {
                return "F";
                }
            return "error";
        }
    }
}
