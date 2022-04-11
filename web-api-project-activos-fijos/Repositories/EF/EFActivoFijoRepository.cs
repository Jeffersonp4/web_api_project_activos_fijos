using web_api_project_activos_fijos.Entities;

namespace web_api_project_activos_fijos.Repositories.EF
{
    public class EFActivoFijoRepository:EFRepository<ActivoFijo, n5xki0m8szpeqpytContext>,IActivoFijo
    {

        private readonly n5xki0m8szpeqpytContext context;

        public EFActivoFijoRepository(n5xki0m8szpeqpytContext context):base(context)
        {
            this.context = context;
        }

        // Metodos Personalizados
    }
}
