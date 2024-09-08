using System.Diagnostics;
using Application.Interfaces;
using Application.Services;
using Blogger.Web.Models;
using Blogger.Web.Models.VMs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ITopicService _topicService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, ITopicService topicService)
        {
            _logger = logger;
            _articleService = articleService;
            _topicService = topicService;
        }

        public async Task<IActionResult> Index()
        {
            // En çok okunan 5 makaleyi al
            var mostReadArticles = await _articleService.GetMostReadArticlesAsync(5);

            // Tüm konuları ve her bir konuya bağlı makaleleri al
            var topicsWithArticles = await _topicService.GetTopicsWithArticlesAsync();

            // ViewModel'i oluştur ve verileri ata
            var model = new HomePageViewModel
            {
                MostReadArticles = mostReadArticles,
                Topics = topicsWithArticles.ToList()
            };

            // Modeli View'e döndür
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
