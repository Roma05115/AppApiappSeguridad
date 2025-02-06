using System;
using System.Collections.Generic;

namespace AppNotificaciones.Models;

public partial class Post
{
    public int IdPost { get; set; }

    public string? TipoIncidente { get; set; }

    public decimal? Altitud { get; set; }

    public decimal? Latitud { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Descripcion { get; set; }

    public string? Imagen { get; set; }

    public int IdUsuario { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
