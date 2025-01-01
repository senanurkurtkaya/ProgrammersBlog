using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.MVC.Models
{
    public class RightSideBarViewModel
    {
        public IList<Category> Categories { get; set; }
        public IList<Article> Articles { get; set; }
    }
}
