namespace web_api_project_activos_fijos.DTOs.ActivoFijo
{
    public class ActivoFijoInfoCreateDTO
    {
        public string ModeloEquipo { get; set; } = null!;
        public string DescripcionActivo { get; set; } = null!;
        public DateTime FechaAdquisicion { get; set; }
        public int NumRegistro { get; set; }
        public string AreaUsuaria { get; set; } = null!;
        public int CostoAdquisicion { get; set; }
        public decimal ValorNeto { get; set; }
        public bool Estado { get; set; }
        public string CodigoTipoActivo { get; set; } = null!;
    }
}
