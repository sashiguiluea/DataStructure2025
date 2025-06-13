using System;
using System.Collections.Generic;

// Clase que representa un estudiante con sus datos personales
public class Estudiante
{
    // Atributo: Identificador único del estudiante
    public int Id { get; set; }

    // Atributo: Nombres del estudiante
    public string Nombres { get; set; }

    // Atributo: Apellidos del estudiante
    public string Apellidos { get; set; }

    // Atributo: Dirección del estudiante
    public string Direccion { get; set; }

    // Atributo: Array que almacena tres números de teléfono
    public string[] Telefonos { get; set; }

    // Constructor de la clase Estudiante que inicializa todos los campos
    public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
    {
        // Validar que se hayan proporcionado exactamente tres teléfonos
        if (telefonos == null || telefonos.Length != 3)
        {
            throw new ArgumentException("Debe proporcionar exactamente tres teléfonos.");
        }

        Id = id;
        Nombres = nombres;
        Apellidos = apellidos;
        Direccion = direccion;
        Telefonos = telefonos;
    }

    // Método ToString sobrescrito para mostrar los datos del estudiante en formato legible
    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombres} {Apellidos}, Dirección: {Direccion}, Teléfonos: [{string.Join(", ", Telefonos)}]";
    }
}

// Clase principal del programa
class RegistroEstudiantes
{
    // Método principal que se ejecuta al iniciar el programa
    static void Main(string[] args)
    {
        // Lista para almacenar estudiantes (se puede expandir a más de uno)
        List<Estudiante> estudiantes = new List<Estudiante>();

        // Agregar tres estudiantes a la lista
        estudiantes.Add(new Estudiante(
            1, "Andrés", "Shigui", "Av. Principal 123",
            new string[] { "987654322", "912345679", "998877667" }
        ));

        estudiantes.Add(new Estudiante(
            2, "Luis", "Suarez", "Calle Secundaria 456",
            new string[] { "912345123", "987650987", "955667788" }
        ));

        estudiantes.Add(new Estudiante(
            3, "Juan", "Montalvo", "Jr. Los Tres Juanes 789",
            new string[] { "934567890", "923456789", "944556677" }
        ));

        // Mostrar en consola los datos del estudiante registrado
        Console.WriteLine("Lista de Estudiantes:\n");
        foreach (var estudiante in estudiantes)
        {
            Console.WriteLine(estudiante);
        }
    }
}

