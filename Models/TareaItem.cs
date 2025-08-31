using System;

namespace Tarea.Api.Models;

public class TareaItem(string nombre, bool EstaCompleta)
{
    public int Id { get; set; } 
    public string Nombre { get; set; } = nombre;
    public bool EstaCompleta { get; set; } = EstaCompleta;
}
