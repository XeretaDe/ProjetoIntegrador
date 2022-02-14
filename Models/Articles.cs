using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIntegrador.Models
{
    public class Articles
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Conteudo { get; set; }
        [Required]
        //[DataType(DataType.Upload)]
        public string Imagem { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        [Required]
        [ForeignKey("aspnetusers")]
        public string FKuser { get; set; }

        [NotMapped]
        public string Username { get; set; }


    }
}
