using ProgrammersBlog.Entities.Dtos;

namespace ProgrammersBlog.MVC.Models
{
    public class ArticleSearchViewModel
    {
        public ArticleListDto ArticleListDto { get; set; }
        public string Keyword { get; set; }
    }
}
