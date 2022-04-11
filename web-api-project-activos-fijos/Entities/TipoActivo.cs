using System;
using System.Collections.Generic;
using web_api_project_activos_fijos.Repositories;

namespace web_api_project_activos_fijos.Entities
{
    public partial class TipoActivo:IId
    {
        public TipoActivo()
        {
            ActivoFijos = new HashSet<ActivoFijo>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string NumeroActivofijo { get; set; } = null!;

        public virtual ICollection<ActivoFijo> ActivoFijos { get; set; }
    }
}
