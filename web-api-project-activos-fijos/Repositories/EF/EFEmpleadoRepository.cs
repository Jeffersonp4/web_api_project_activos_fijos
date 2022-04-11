using web_api_project_activos_fijos.Entities;

namespace web_api_project_activos_fijos.Repositories.EF
{
    public class EFEmpleadoRepository:EFRepository<Empleado, n5xki0m8szpeqpytContext>,IEmpleado
    {
        private readonly n5xki0m8szpeqpytContext context;

        public EFEmpleadoRepository(n5xki0m8szpeqpytContext context):base(context)
        {
            this.context = context;
        }

        // Metodos Personalizados
    }
}
