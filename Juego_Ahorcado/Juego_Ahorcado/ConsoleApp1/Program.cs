// Juego del Ahorcado - Desafío 2
// Alumno: Dana Burgos BE260699

bool salir = false;

while (!salir)
{
    Console.Clear();
    Console.WriteLine("=== JUEGO DEL AHORCADO ===");
    Console.WriteLine("1. Jugar");
    Console.WriteLine("2. Ver instrucciones");
    Console.WriteLine("3. Salir");
    Console.Write("Seleccione una opción: ");
    string opcion = Console.ReadLine();

    if (opcion == "1")
    {
        Jugar();
    }
    else if (opcion == "2")
    {
        MostrarInstrucciones();
    }
    else if (opcion == "3")
    {
        salir = true;
    }
    else
    {
        Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
        Console.ReadKey();
    }
}
