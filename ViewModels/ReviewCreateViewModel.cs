using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIntegrador.ViewModels
{
    public class ReviewCreateViewModel
    {

        [Required]
        [StringLength(100)]
        public string TitleReview { get; set; }
        [Required]
        public string DescriptionReview { get; set; }
        [Required]
        public string ContentReview { get; set; }
        [Required]
        //[DataType(DataType.Upload)]
        public IFormFile Photo { get; set; }

        [Required]
        public int Grade { get; set; }
        public string FKUser { get; set; }

        public string Username { get; set; }

        public int Id { get; set; }
    }
}
