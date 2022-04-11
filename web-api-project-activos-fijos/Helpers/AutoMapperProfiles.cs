using AutoMapper;
using web_api_project_activos_fijos.DTOs.ActivoFijo;
using web_api_project_activos_fijos.DTOs.Empleado;
using web_api_project_activos_fijos.DTOs.TipoActivo;
using web_api_project_activos_fijos.Entities;

namespace web_api_project_activos_fijos.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //Mapeo para los empleados 

            CreateMap<PaginationGeneric<Empleado>, PaginationGeneric<EmpleadoInfoDTO>>().ReverseMap();
            CreateMap<Empleado, EmpleadoInfoDTO>().ReverseMap();
            CreateMap<EmpleadoInfoCreateDTO, Empleado>();

            //Mapeo para los Activos

            CreateMap<PaginationGeneric<ActivoFijo>, PaginationGeneric<ActivoFijoInfoDTO>>().ReverseMap();
            CreateMap<ActivoFijo, ActivoFijoInfoDTO>().ReverseMap();
            CreateMap<ActivoFijoInfoCreateDTO, ActivoFijo>();

            //Mapeo para los tipos de activos

            CreateMap<PaginationGeneric<TipoActivo>, PaginationGeneric<TipoActivoInfoDTO>>().ReverseMap();
            CreateMap<TipoActivo, TipoActivoInfoDTO>().ReverseMap();
            CreateMap<TipoActivoInfoCreateDTO, TipoActivo>();
        }
    }
}
