using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppNotificaciones.Models;

public partial class Contacto
{
    public int IdContacto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Numero { get; set; }

    public string? Descripcion { get; set; }

    public string? Imagen { get; set; }

}
