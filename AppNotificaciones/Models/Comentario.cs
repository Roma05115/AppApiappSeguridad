using System;
using System.Collections.Generic;

namespace AppNotificaciones.Models;

public partial class Comentario
{
    public int IdComentario { get; set; }

    public string Contenido { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public int? IdUsuario { get; set; }

    public int IdPost { get; set; }

    public virtual Post IdPostNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
