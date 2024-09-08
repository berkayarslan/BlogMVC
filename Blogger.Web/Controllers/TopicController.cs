using Application.DTOs.TopicDTOs;
using Application.Interfaces;
using Application.Services;
using Blogger.Web.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Web.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly IArticleService _articleService;

        public TopicController(ITopicService topicService, IArticleService articleService)
        {
            _topicService = topicService;
            _articleService = articleService;
        }

        // GET: /Topic/Index
        public async Task<IActionResult> Index()
        {
            var topics = await _topicService.GetAllTopicsAsync();
            return View(topics);
        }

        // GET: /Topic/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Topic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTopicDto model)
        {
            if (ModelState.IsValid)
            {
                var topicId = await _topicService.CreateTopicAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var topic = await _topicService.GetTopicByIdAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            var model = new TopicDto
            {
                Id = topic.Id,
                Name = topic.Name,
                Articles = topic.Articles,
                ArticleTopics = topic.ArticleTopics,
                
                
            };
            return View(model);
        }

        // POST: /Topic/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TopicDto model)
        {
            if (ModelState.IsValid)
            {
                await _topicService.UpdateTopicAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // POST: /Topic/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _topicService.DeleteTopicAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
