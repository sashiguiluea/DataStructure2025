/// <summary>
/// Representa un visitante en el parque de diversiones
/// </summary>
public class Visitante
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public DateTime HoraLlegada { get; set; }
    public int NumeroAsiento { get; set; }

    public Visitante(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
        HoraLlegada = DateTime.Now;
        NumeroAsiento = 0;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Asiento: {NumeroAsiento}, Llegada: {HoraLlegada:HH:mm:ss}";
    }
}