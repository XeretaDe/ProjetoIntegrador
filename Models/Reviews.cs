using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIntegrador.Models
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Column("Conteudo")]
        public string ContentReview { get; set; }

        [Required]
        [Column("Score")]
        public int Grade { get; set; }
        [Required]
        //[DataType(DataType.Upload)]
        [Column("Image")]
        public string Imagem { get; set; }


        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }

        [Required]
        [ForeignKey("aspnetusers")]
        [Column("User")]
        public string IdAutor { get; set; }

        [NotMapped]
        public string Username { get; set; }
    }
}
