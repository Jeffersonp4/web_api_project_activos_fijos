using System.ComponentModel.DataAnnotations;

namespace web_api_project_activos_fijos.DTOs.Identity
{
    public class CredencialesUsuario
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
    }
}
