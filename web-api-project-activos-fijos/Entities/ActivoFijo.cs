using System;
using System.Collections.Generic;
using web_api_project_activos_fijos.Repositories;

namespace web_api_project_activos_fijos.Entities
{
    public partial class ActivoFijo:IId
    {
        public int Id { get; set; }
        public string ModeloEquipo { get; set; } = null!;
        public string DescripcionActivo { get; set; } = null!;
        public DateTime FechaAdquisicion { get; set; }
        public int NumRegistro { get; set; }
        public string AreaUsuaria { get; set; } = null!;
        public int CostoAdquisicion { get; set; }
        public decimal ValorNeto { get; set; }
        public bool Estado { get; set; }
        public string CodigoTipoActivo { get; set; } = null!;

        public virtual TipoActivo CodigoTipoActivoNavigation { get; set; } = null!;
    }
}
