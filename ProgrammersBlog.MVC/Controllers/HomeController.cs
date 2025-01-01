using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using Microsoft.Extensions.Options;

using ProgrammersBlog.MVC.Models;
using ProgrammersBlog.Services.Abstract;

using ProgrammersBlog.Shared.Utilities.Helpers.Abstract.WritableOptionsHelper;

using System.Diagnostics;

namespace ProgrammersBlog.MVC.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IMailService _mailService;
        private readonly IToastNotification _toastNotification;

        public HomeController(IArticleService articleService, IOptionsSnapshot<AboutUsPageInfo> aboutUsPageInfo, IMailService mailService, IToastNotification toastNotification, IOptions<AboutUsPageInfo> aboutUsPageInfoWriter)
        {
            _articleService = articleService;
            _mailService = mailService;
            _toastNotification = toastNotification;
            _aboutUsPageInfo = aboutUsPageInfo.Value;

        }

        [Route("index")]
        [Route("anasayfa")]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index(int? categoryId, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        {
            var articlesResult = await (categoryId == null
                ? _articleService.GetAllByPagingAsync(null, currentPage, pageSize, isAscending)
                : _articleService.GetAllByPagingAsync(categoryId.Value, currentPage, pageSize, isAscending));
            return View(articlesResult.Data);
        }

        [Route("about")]
        [Route("hakkimizda")]
        [Route("hakkkinda")]
        [HttpGet]
        public IActionResult About()
        {
            //_aboutUsPageInfoWriter.Update(x=>x.Header="Yeni Baþlýk");
            return View(_aboutUsPageInfo);
        }

        [Route("iletisim")]
        [Route("contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("iletisim")]
        [Route("contact")]
        [HttpPost]
        public IActionResult Contact(EmailSendDto emailSendDto)
        {
            if (ModelState.IsValid)
            {
                var result = _mailService.SendContactEmail(emailSendDto);
                _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                {
                    Title = "Baþarýlý Ýþlem!"
                });
                return View();
            }
            return View(emailSendDto);
        }
    }
}
