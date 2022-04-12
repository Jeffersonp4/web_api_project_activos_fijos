namespace web_api_project_activos_fijos.DTOs.TipoActivo
{
    public class TipoActivoInfoCreateDTO
    {

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string NumeroActivofijo { get; set; } = null!;
    }
}
