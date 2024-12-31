using Microsoft.AspNetCore.Mvc;
using ProgrammersBlog.MVC.Models;
using System.Diagnostics;

namespace ProgrammersBlog.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class HomeController : Controller
    {
   

        public IActionResult Index()
        {
            return View();
        }

    }
}
