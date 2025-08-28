//Clase Diccionario.cs - contiene la implementación del traductor
public static class DiccionarioTraductor
{
    // Diccionario inicial con al menos 10 palabras (usando Dictionary como se requiere)
    static Dictionary<string, string> diccionario = new Dictionary<string, string>()
    {
        {"time", "tiempo"}, {"person", "persona"}, {"year", "año"},
        {"way", "camino"}, {"day", "día"}, {"thing", "cosa"},
        {"man", "hombre"}, {"world", "mundo"}, {"life", "vida"},
        {"hand", "mano"}, {"part", "parte"}, {"child", "niño/a"},
        {"eye", "ojo"}, {"woman", "mujer"}, {"place", "lugar"},
        {"work", "trabajo"}, {"week", "semana"}, {"case", "caso"},
        {"point", "punto"}, {"government", "gobierno"}, {"company", "empresa"}
    };
    // Método principal para ejecutar el traductor
    public static void Run()
    {
        // Crear diccionario bidireccional usando UN SOLO Dictionary
        Dictionary<string, string> diccionarioBidireccional = new Dictionary<string, string>();

        // Agregar traducciones inglés → español
        foreach (var kvp in diccionario)
        {
            diccionarioBidireccional[kvp.Key.ToLower()] = kvp.Value.ToLower();
        }

        // Agregar traducciones español → inglés
        foreach (var kvp in diccionario)
        {
            diccionarioBidireccional[kvp.Value.ToLower()] = kvp.Key.ToLower();
        }

        diccionario = diccionarioBidireccional;

        while (true)
        {
            // Menú EXACTAMENTE como se especifica en los requerimientos
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine()?.Trim() ?? "";

            if (opcion == "0")
                break;
            else if (opcion == "1")
                TraducirFrase();
            else if (opcion == "2")
                AgregarPalabra();
            else
                Console.WriteLine("Opción inválida.");
        }
    }
    // Método para traducir una frase
    static void TraducirFrase()
    {
        Console.Write("Ingrese la frase: ");
        string frase = Console.ReadLine()?.Trim() ?? "";
        string[] palabras = frase.Split(' ');

        for (int i = 0; i < palabras.Length; i++)
        {
            // Manejo de puntuación - extraer signos al inicio y final
            string palabraCompleta = palabras[i];
            string signosIniciales = "";
            string signosFinales = "";
            string palabraSola = palabraCompleta;

            // Extraer signos de puntuación al inicio
            while (palabraSola.Length > 0 && !char.IsLetter(palabraSola[0]))
            {
                signosIniciales += palabraSola[0];
                palabraSola = palabraSola.Substring(1);
            }

            // Extraer signos de puntuación al final
            while (palabraSola.Length > 0 && !char.IsLetter(palabraSola[palabraSola.Length - 1]))
            {
                signosFinales = palabraSola[palabraSola.Length - 1] + signosFinales;
                palabraSola = palabraSola.Substring(0, palabraSola.Length - 1);
            }

            // SOLO traducir si la palabra existe en el diccionario
            if (palabraSola.Length > 0 && diccionario.ContainsKey(palabraSola.ToLower()))
            {
                string traduccion = diccionario[palabraSola.ToLower()];
                // Preservar mayúscula inicial si la palabra original la tiene
                if (palabraSola.Length > 0 && char.IsUpper(palabraSola[0]))
                {
                    traduccion = char.ToUpper(traduccion[0]) + traduccion.Substring(1);
                }
                palabras[i] = signosIniciales + traduccion + signosFinales;
            }
            // Si NO existe en el diccionario, mantener la palabra original sin cambios
        }
        // Mostrar la frase traducida
        Console.WriteLine("Su frase traducida es: " + string.Join(" ", palabras));
    }
    // Método para agregar una nueva palabra al diccionario
    static void AgregarPalabra()
    {
        // Orden correcto: PRIMERO inglés, DESPUÉS español
        Console.Write("Ingrese la palabra en inglés: ");
        string ingles = Console.ReadLine()?.Trim().ToLower() ?? "";

        Console.Write("Ingrese la traducción en español: ");
        string espanol = Console.ReadLine()?.Trim().ToLower() ?? "";

        // Verificar que las palabras no existan ya en el diccionario
        if (!diccionario.ContainsKey(ingles) && !diccionario.ContainsKey(espanol))
        {
            // Agregar bidireccionalidad al diccionario
            diccionario[ingles] = espanol;
            diccionario[espanol] = ingles;
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}