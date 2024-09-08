using System.Security.Claims;
using Application.DTOs.ArticleDTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public ArticleController(IArticleService articleService, IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _articleService = articleService;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        // GET: /Article/Index
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetMostReadArticlesAsync(10);
            return View(articles);
        }

        // GET: /Article/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var article = await _articleService.GetArticleByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // GET: /Article/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateArticleDto model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "User"); // Oturum sona erdiğinde yönlendirme
            }
            model.AuthorId = user.Id;

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(model);
            }

            await _articleService.CreateArticleAsync(model);
            await _unitOfWork.SaveAsync();
            return RedirectToAction("Profile", "User", new { id = model.AuthorId });
        }

        // GET: /Article/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var article = await _articleService.GetArticleByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: /Article/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ArticleDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _articleService.UpdateArticleAsync(model);
            await _unitOfWork.SaveAsync();
            return RedirectToAction("Profile", "User", new { id = model.AuthorId });
        }

        // POST: /Article/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Delete(Guid id)
        {
            await _articleService.DeleteArticleAsync(id);
            await _unitOfWork.SaveAsync();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return RedirectToAction("Profile", "User", new { id = userId });
        }
    }
}
