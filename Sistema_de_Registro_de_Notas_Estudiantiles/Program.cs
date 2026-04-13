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
                    notas[i] = nota;
                    if (!valido)
                    {
                        Console.WriteLine("Ingrese un numero valido");
                    }
                    else if(nota<0 || nota>10)
                    {
                        Console.WriteLine("Ingrese un numero valido");
                        valido = false;
                    }
                } while (!valido);
            }
            //debugging
            for (int i = 0; i< alumnos.Length;i++)
            {
                Console.WriteLine(notas[i]);
            }


            //evitamos que el programa se cierre solo 
            Console.ReadKey();
        }
     
    }
}
