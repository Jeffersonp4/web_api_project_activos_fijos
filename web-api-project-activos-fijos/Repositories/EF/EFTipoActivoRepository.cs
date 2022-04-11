using web_api_project_activos_fijos.Entities;

namespace web_api_project_activos_fijos.Repositories.EF
{
    public class EFTipoActivoRepository:EFRepository<TipoActivo, n5xki0m8szpeqpytContext>,ITipoActivo
    {
        private readonly n5xki0m8szpeqpytContext context;

        public EFTipoActivoRepository(n5xki0m8szpeqpytContext context):base(context)
        {
            this.context = context;
        }

        // Metodos Personalizados
    }
}
