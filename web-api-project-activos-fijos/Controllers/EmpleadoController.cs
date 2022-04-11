using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_project_activos_fijos.DTOs.Empleado;
using web_api_project_activos_fijos.Entities;
using web_api_project_activos_fijos.Repositories.EF;

namespace web_api_project_activos_fijos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : CustomBaseController<Empleado,EmpleadoInfoDTO,EmpleadoInfoCreateDTO,EFEmpleadoRepository>
    {
        public EmpleadoController(EFEmpleadoRepository repository,IMapper mapper):base(repository,mapper)
        {

        }

        //ENDPOINTS PERSONALIZADOS
    }
}
