using System;
using System.Collections.Generic;
using web_api_project_activos_fijos.Repositories;

namespace web_api_project_activos_fijos.Entities
{
    public partial class Empleado:IId
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Celular { get; set; } = null!;
    }
}
