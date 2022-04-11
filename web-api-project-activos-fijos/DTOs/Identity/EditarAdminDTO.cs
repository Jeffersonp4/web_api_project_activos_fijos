using System.ComponentModel.DataAnnotations;

namespace web_api_project_activos_fijos.DTOs.Identity
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
