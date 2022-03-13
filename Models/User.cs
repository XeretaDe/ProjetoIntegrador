using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Models
{
    public class User
    {
        [Key]
        public string IdUser { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Esse campo precisa ser um Email")]
        public string Login { get; set; }
        [Required]
        public string NomeUsuario{ get; set; }

        [NotMapped]
        public bool Logado { get; set; }

        [NotMapped]
        public List<User> UserLogado { get; set; }
    }
}
