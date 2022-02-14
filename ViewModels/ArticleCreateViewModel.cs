using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIntegrador.ViewModels
{
    public class ArticleCreateViewModel
    {

        [Required]
        [StringLength(100)]
        public string TitleArticle { get; set; }
        [Required]
        public string DescriptionArticle { get; set; }
        [Required]
        public string ContentArticle { get; set; }
        [Required]
        //[DataType(DataType.Upload)]
        public IFormFile Photo { get; set; }
        public string FKUser { get; set; }

        public string Username { get; set; }

        public int Id { get; set; }
    }
}
