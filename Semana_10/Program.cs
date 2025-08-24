using iTextSharp.text;
using iTextSharp.text.pdf;

/// <summary>
/// Representa a una persona en el sistema de vacunación
/// </summary>
class Persona
{
    /// <summary>
    /// Nombre de la persona (ej: "Ciudadano 1")
    /// </summary>
    public string Nombre { get; private set; }

    /// <summary>
    /// Constructor que inicializa una nueva persona
    /// </summary>
    /// <param name="nombre">Nombre de la persona</param>
    public Persona(string nombre)
    {
        Nombre = nombre;
    }

    /// <summary>
    /// Devuelve la representación en string de la persona (su nombre)
    /// </summary>
    /// <returns>Nombre de la persona</returns>
    public override string ToString()
    {
        return Nombre;
    }

    /// <summary>
    /// Compara dos objetos Persona para determinar si son iguales
    /// </summary>
    /// <param name="obj">Objeto a comparar</param>
    /// <returns>True si son la misma persona, False en caso contrario</returns>
    public override bool Equals(object obj)
    {
        return obj is Persona persona && Nombre == persona.Nombre;
    }

    /// <summary>
    /// Obtiene el código hash de la persona basado en su nombre
    /// </summary>
    /// <returns>Código hash del nombre</returns>
    public override int GetHashCode()
    {
        return Nombre.GetHashCode();
    }
}

/// <summary>
/// Gestiona toda la campaña de vacunación COVID-19 utilizando operaciones de teoría de conjuntos
/// </summary>
class CampañaCovid
{
    private HashSet<Persona> ciudadanos;
    private HashSet<Persona> vacunadosPfizer;
    private HashSet<Persona> vacunadosAstraZeneca;

    /// <summary>
    /// Constructor que inicializa la campaña con ciudadanos y asignación de vacunas
    /// </summary>
    /// <param name="totalCiudadanos">Número total de ciudadanos a crear</param>
    /// <param name="totalPfizer">Número de vacunados con Pfizer</param>
    /// <param name="totalAstraZeneca">Número de vacunados con AstraZeneca</param>
    public CampañaCovid(int totalCiudadanos, int totalPfizer, int totalAstraZeneca)
    {
        // Crear conjunto de todos los ciudadanos (500)
        ciudadanos = new HashSet<Persona>();
        for (int i = 1; i <= totalCiudadanos; i++)
        {
            ciudadanos.Add(new Persona($"Ciudadano {i}"));
        }

        Random rnd = new Random();
        vacunadosPfizer = new HashSet<Persona>();
        vacunadosAstraZeneca = new HashSet<Persona>();

        // OPERACIÓN: Asignación aleatoria de vacunas Pfizer
        while (vacunadosPfizer.Count < totalPfizer)
        {
            int numero = rnd.Next(1, totalCiudadanos + 1);
            vacunadosPfizer.Add(new Persona($"Ciudadano {numero}"));
        }

        // OPERACIÓN: Asignación aleatoria de vacunas AstraZeneca
        while (vacunadosAstraZeneca.Count < totalAstraZeneca)
        {
            int numero = rnd.Next(1, totalCiudadanos + 1);
            vacunadosAstraZeneca.Add(new Persona($"Ciudadano {numero}"));
        }
    }

    /// <summary>
    /// Propiedad que devuelve el total de ciudadanos en la campaña
    /// </summary>
    public int TotalCiudadanos => ciudadanos.Count;

    /// <summary>
    /// OPERACIÓN DE CONJUNTOS: Diferencia entre todos los ciudadanos y la unión de vacunados
    /// Calcula los ciudadanos que NO han recibido ninguna vacuna
    /// </summary>
    /// <returns>Conjunto de personas no vacunadas</returns>
    public HashSet<Persona> ObtenerNoVacunados()
    {
        // ciudadanos - (vacunadosPfizer ∪ vacunadosAstraZeneca)
        return new HashSet<Persona>(ciudadanos.Except(vacunadosPfizer.Union(vacunadosAstraZeneca)));
    }

    /// <summary>
    /// OPERACIÓN DE CONJUNTOS: Intersección entre vacunados con Pfizer y AstraZeneca
    /// Calcula los ciudadanos que han recibido AMBAS vacunas
    /// </summary>
    /// <returns>Conjunto de personas con ambas dosis</returns>
    public HashSet<Persona> ObtenerAmbasDosis()
    {
        // vacunadosPfizer ∩ vacunadosAstraZeneca
        return new HashSet<Persona>(vacunadosPfizer.Intersect(vacunadosAstraZeneca));
    }

    /// <summary>
    /// OPERACIÓN DE CONJUNTOS: Diferencia entre vacunados Pfizer y AstraZeneca
    /// Calcula los ciudadanos que SOLO recibieron Pfizer
    /// </summary>
    /// <returns>Conjunto de personas solo con Pfizer</returns>
    public HashSet<Persona> ObtenerSoloPfizer()
    {
        // vacunadosPfizer - vacunadosAstraZeneca
        return new HashSet<Persona>(vacunadosPfizer.Except(vacunadosAstraZeneca));
    }

    /// <summary>
    /// OPERACIÓN DE CONJUNTOS: Diferencia entre vacunados AstraZeneca y Pfizer
    /// Calcula los ciudadanos que SOLO recibieron AstraZeneca
    /// </summary>
    /// <returns>Conjunto de personas solo con AstraZeneca</returns>
    public HashSet<Persona> ObtenerSoloAstraZeneca()
    {
        // vacunadosAstraZeneca - vacunadosPfizer
        return new HashSet<Persona>(vacunadosAstraZeneca.Except(vacunadosPfizer));
    }

    /// <summary>
    /// Genera un reporte completo en formato PDF con todos los resultados de la campaña
    /// </summary>
    public void GenerarReporte()
    {
        string ruta = "Reporte_Vacunacion.pdf";
        Document doc = new Document();
        PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
        doc.Open();

        // Encabezado institucional del reporte
        doc.Add(new Paragraph("UNIVERSIDAD ESTATAL AMAZÓNICA"));
        doc.Add(new Paragraph("FACULTAD DE CIENCIAS DE LA EDUCACIÓN"));
        doc.Add(new Paragraph("INGENIERÍA EN TECNOLOGÍAS DE LA INFORMACIÓN"));
        doc.Add(new Paragraph("Desarrollado por: Andrés Shigui"));
        doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}"));
        doc.Add(new Paragraph("\nReporte de Vacunación COVID-19"));
        doc.Add(new Paragraph("=================================================="));

        // Resumen estadístico usando los resultados de las operaciones de conjuntos
        doc.Add(new Paragraph("\nRESUMEN ESTADÍSTICO:"));
        doc.Add(new Paragraph($"Total de ciudadanos: {TotalCiudadanos}"));
        doc.Add(new Paragraph($"No vacunados: {ObtenerNoVacunados().Count}"));
        doc.Add(new Paragraph($"Vacunados con ambas dosis: {ObtenerAmbasDosis().Count}"));
        doc.Add(new Paragraph($"Solo vacunados con Pfizer: {ObtenerSoloPfizer().Count}"));
        doc.Add(new Paragraph($"Solo vacunados con AstraZeneca: {ObtenerSoloAstraZeneca().Count}"));
        doc.Add(new Paragraph("=================================================="));

        // Secciones detalladas con listas de personas
        AgregarListaAlPDF(doc, "CIUDADANOS NO VACUNADOS", ObtenerNoVacunados());
        AgregarListaAlPDF(doc, "CIUDADANOS VACUNADOS CON AMBAS DOSIS", ObtenerAmbasDosis());
        AgregarListaAlPDF(doc, "CIUDADANOS SOLO VACUNADOS CON PFIZER", ObtenerSoloPfizer());
        AgregarListaAlPDF(doc, "CIUDADANOS SOLO VACUNADOS CON ASTRAZENECA", ObtenerSoloAstraZeneca());

        doc.Close();
        Console.WriteLine($"Reporte PDF generado con éxito en '{Path.GetFullPath(ruta)}'.");
    }

    /// <summary>
    /// Método auxiliar para agregar una lista de personas al documento PDF
    /// </summary>
    /// <param name="doc">Documento PDF donde se agregará la lista</param>
    /// <param name="titulo">Título de la sección</param>
    /// <param name="lista">Conjunto de personas a listar</param>
    private void AgregarListaAlPDF(Document doc, string titulo, HashSet<Persona> lista)
    {
        doc.Add(new Paragraph($"\n{titulo}: ({lista.Count} personas)"));
        doc.Add(new Paragraph("--------------------------------------------------"));

        int contador = 1;
        // Ordenar alfabéticamente para mejor presentación
        foreach (var persona in lista.OrderBy(p => p.Nombre))
        {
            doc.Add(new Paragraph($"{contador}. {persona.Nombre}"));
            contador++;
        }
    }
}

/// <summary>
/// Clase principal que contiene el punto de entrada del programa
/// </summary>
class Program
{
    /// <summary>
    /// Método principal que ejecuta toda la aplicación
    /// </summary>
    static void Main()
    {
        // Encabezado del sistema
        Console.WriteLine("==================================================");
        Console.WriteLine("         UNIVERSIDAD ESTATAL AMAZÓNICA");
        Console.WriteLine(" FACULTAD DE CIENCIAS DE LA EDUCACIÓN");
        Console.WriteLine(" INGENIERÍA EN TECNOLOGÍAS DE LA INFORMACIÓN");
        Console.WriteLine("         Desarrollado por: Andrés Shigui");
        Console.WriteLine("==================================================");
        Console.WriteLine();
        Console.WriteLine("SISTEMA DE GESTIÓN DE VACUNACIÓN COVID-19\n");

        // Crear la campaña con los parámetros especificados: 500 ciudadanos, 75 Pfizer, 75 AstraZeneca
        CampañaCovid campaña = new CampañaCovid(500, 75, 75);

        // Mostrar resultados utilizando notación de teoría de conjuntos
        Console.WriteLine("RESULTADOS DE LA CAMPAÑA DE VACUNACIÓN:");
        Console.WriteLine($"├─ Total de ciudadanos: {campaña.TotalCiudadanos}");
        Console.WriteLine($"├─ Ciudadanos no vacunados: {campaña.ObtenerNoVacunados().Count}");
        Console.WriteLine($"├─ Ciudadanos con ambas dosis (P ∩ A): {campaña.ObtenerAmbasDosis().Count}");
        Console.WriteLine($"├─ Solo vacunados con Pfizer (P - A): {campaña.ObtenerSoloPfizer().Count}");
        Console.WriteLine($"└─ Solo vacunados con AstraZeneca (A - P): {campaña.ObtenerSoloAstraZeneca().Count}");

        // Generar reporte en PDF
        Console.WriteLine("\nGenerando reporte PDF...");
        campaña.GenerarReporte();

        // Mensaje final de confirmación
        Console.WriteLine("\nProceso completado exitosamente.");
        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
