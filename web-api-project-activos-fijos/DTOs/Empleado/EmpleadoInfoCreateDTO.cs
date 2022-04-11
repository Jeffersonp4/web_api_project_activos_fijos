namespace web_api_project_activos_fijos.DTOs.Empleado
{
    public class EmpleadoInfoCreateDTO
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Celular { get; set; } = null!;
    }
}
