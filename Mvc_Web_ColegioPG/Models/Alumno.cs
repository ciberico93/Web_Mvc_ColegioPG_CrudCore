using System;
using System.Collections.Generic;

namespace CRUD_COLEGIO_APP_0609.Models;

public partial class Alumno
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int? IdCursos { get; set; }

    public virtual Curso? IdCursosNavigation { get; set; }
}
