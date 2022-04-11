using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_project_activos_fijos.DTOs.ActivoFijo;
using web_api_project_activos_fijos.Entities;
using web_api_project_activos_fijos.Repositories.EF;

namespace web_api_project_activos_fijos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivoFijoController : CustomBaseController<ActivoFijo,ActivoFijoInfoDTO,ActivoFijoInfoCreateDTO,EFActivoFijoRepository>
    {
        public ActivoFijoController(EFActivoFijoRepository repository, IMapper mapper):base(repository,mapper)
        {

        }

        // ENDPOINTS PERSONALIZADOS


    }
}
