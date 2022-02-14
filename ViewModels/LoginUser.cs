using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador.ViewModels
{
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembre de mim")]
        public bool RememberMe { get; set; }
    }
}
