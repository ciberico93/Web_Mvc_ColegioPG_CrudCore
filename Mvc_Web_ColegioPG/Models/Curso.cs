using System;
using System.Collections.Generic;

namespace CRUD_COLEGIO_APP_0609.Models;

public partial class Curso
{
    public int IdCursos { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();


}
