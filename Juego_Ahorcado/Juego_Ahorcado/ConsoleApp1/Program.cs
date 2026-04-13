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

// Esta función es para mostrar instrucciones
void MostrarInstrucciones()
{
    Console.Clear();
    Console.WriteLine("    INSTRUCCIONES    ");
    Console.WriteLine("El sistema selecciona una palabra al azar de un banco de 10.");
    Console.WriteLine("Debes adivinar la palabra ingresando letras.");
    Console.WriteLine("Solo tienes 6 intentos antes de perder.");
    Console.WriteLine("No puedes repetir letras ya usadas.");
    Console.WriteLine("Ganas si completas la palabra antes de agotar los intentos.");
    Console.WriteLine("\nPresione una tecla para volver al menú...");
    Console.ReadKey();
}

// Función principal del juego
void Jugar()
{
    string[] bancoPalabras = { "programacion", "algoritmo", "computadora", "teclado", "pantalla", "universidad", "ingenieria", "ahorcado", "estudiante", "csharp" };
    Random rnd = new Random();
    string palabra = bancoPalabras[rnd.Next(bancoPalabras.Length)];
    char[] estado = new string('_', palabra.Length).ToCharArray();
    List<char> letrasUsadas = new List<char>();
    int intentos = 6;

    while (intentos > 0 && new string(estado) != palabra)
    {
        Console.Clear();
        Console.WriteLine("    JUEGO DEL AHORCADO    ");
        DibujarAhorcado(intentos);
        Console.WriteLine("Palabra: " + new string(estado));
        Console.WriteLine("Letras usadas: " + string.Join(", ", letrasUsadas));
        Console.WriteLine("Intentos restantes: " + intentos);
        Console.Write("Ingrese una letra: ");
        string entrada = Console.ReadLine().ToLower();

        // Validación de entrada
        if (entrada.Length != 1 || !char.IsLetter(entrada[0]))
        {
            Console.WriteLine("Entrada inválida. Presione una tecla.");
            Console.ReadKey();
            continue;
        }

        char letra = entrada[0];
        if (letrasUsadas.Contains(letra))
        {
            Console.WriteLine("Ya usaste esa letra. Presione una tecla.");
            Console.ReadKey();
            continue;
        }

        letrasUsadas.Add(letra);
        if (palabra.Contains(letra))
        {
            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i] == letra)
                    estado[i] = letra;
            }
        }
        else
        {
            intentos--;
        }
    }

    Console.Clear();
    if (new string(estado) == palabra)
    {
        Console.WriteLine("¡Felicidades! Ganaste. La palabra era: " + palabra);
    }
    else
    {
        DibujarAhorcado(0);
        Console.WriteLine("Perdiste. La palabra era: " + palabra);
    }

    Console.Write("\n¿Desea jugar de nuevo? (s/n): ");
    string respuesta = Console.ReadLine().ToLower();
    if (respuesta == "s")
        Jugar();
}

// Función para dibujar el ahorcado
void DibujarAhorcado(int intentos)
{
    string[] dibujo = {
        " +---+\n |   |\n O   |\n/|\\  |\n/ \\  |\n     |\n=======",
        " +---+\n |   |\n O   |\n/|\\  |\n/    |\n     |\n=======",
        " +---+\n |   |\n O   |\n/|\\  |\n     |\n     |\n=======",
        " +---+\n |   |\n O   |\n/|   |\n     |\n     |\n=======",
        " +---+\n |   |\n O   |\n |   |\n     |\n     |\n=======",
        " +---+\n |   |\n O   |\n     |\n     |\n     |\n=======",
        " +---+\n |   |\n     |\n     |\n     |\n     |\n======="
    };
    Console.WriteLine(dibujo[6 - intentos]);
}