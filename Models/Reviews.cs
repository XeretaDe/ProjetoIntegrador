﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIntegrador.Models
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string TitleReview { get; set; }
        [Required]
        public string DescriptionReview { get; set; }
        [Required]
        public string ContentReview { get; set; }

        [Required]
        public int Grade { get; set; }
        [Required]
        //[DataType(DataType.Upload)]
        public string Imagem { get; set; }


        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }

        [Required]
        [ForeignKey("aspnetusers")]
        public string IdAutor { get; set; }

        [NotMapped]
        public string Username { get; set; }
    }
}
