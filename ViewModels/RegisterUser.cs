using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador.ViewModels
{
    public class RegisterUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "O login tem que estar no formato de e-mail")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirmar senha")]
        [Compare("Password",
            ErrorMessage = "Senha inserida e a confirmação diferem")]
        public string confirmSenha { get; set; }

    }
}
