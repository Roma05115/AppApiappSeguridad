using System;
using System.Collections.Generic;

namespace AppNotificaciones.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Rol { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
