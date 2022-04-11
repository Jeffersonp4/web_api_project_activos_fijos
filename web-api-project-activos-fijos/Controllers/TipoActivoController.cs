using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_project_activos_fijos.DTOs.TipoActivo;
using web_api_project_activos_fijos.Entities;
using web_api_project_activos_fijos.Repositories.EF;

namespace web_api_project_activos_fijos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoActivoController : CustomBaseController<TipoActivo,TipoActivoInfoDTO,TipoActivoInfoCreateDTO,EFTipoActivoRepository>
    {
        public TipoActivoController(EFTipoActivoRepository repository, IMapper mapper):base(repository, mapper)
        {
            
        }
    }
}
