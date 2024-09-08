using Application.DTOs.UserDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Domain.Entities;
using AutoMapper;
using Application.Services;
using System.Security.Claims;
using Blogger.Web.Models.VMs;
using Application.DTOs.ArticleDTOs;
using NuGet.Packaging;
using Blogger.Web.Models.VMs;
using Application.DTOs.TopicDTOs;

namespace Blogger.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        private readonly IUserTopicService _userTopicService;
        private readonly ITopicService _topicservice;

        public UserController(IUserService userService, SignInManager<User> signInManager, UserManager<User> userManager, IFileService fileService, IMapper mapper, IArticleService articleService , IUserTopicService userTopicService , ITopicService topicservice)
        {
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
            _fileService = fileService;
            _mapper = mapper;
            _articleService = articleService;
            _userTopicService = userTopicService;
            _topicservice = topicservice;
        }

        // GET: /User/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateUserDto model)
        {
            if (ModelState.IsValid)
            {
                var userId = await _userService.CreateUserAsync(model);
                return RedirectToAction(nameof(Profile), new { id = userId });
            }
            return View(model);
        }

        // GET: /User/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);
                    return RedirectToAction("Profile", "User", new { id = user.Id });
                }
                else if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Your account is locked out.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Profile(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var followedTopics = await _userTopicService.GetFollowedTopicsAsync(id);
            var allTopics = await _topicservice.GetAllTopicsAsync();
            var articles = await _articleService.GetArticlesByUserIdAsync(id);

            var model = new UserProfileViewModel
            {
                User = _mapper.Map<UpdateUserDto>(user),
                Topics = followedTopics?.ToList() ?? new List<TopicDto>(),
                AllTopics = allTopics.ToList(),
                Articles = articles?.ToList() ?? new List<ArticleDto>()
            };

            return View(model);
        }




        // GET: /User/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<UpdateUserDto>(user);
            return View(model);
        }

        // POST: /User/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateUserDto model)
        {
            if (ModelState.IsValid)
            {
                // Eğer yeni bir profil resmi yüklendiyse
                if (model.ProfileImage != null)
                {
                    // Yeni resmi yükleyip URL'yi alıyoruz
                    model.ExistingProfileImageUrl = await _fileService.UploadFileAsync(model.ProfileImage, "uploads/profile_images");
                }
                else
                {
                    // Yeni bir resim yüklenmediyse mevcut resim URL'sini koruyoruz
                    var existingUser = await _userService.GetUserByIdAsync(model.Id);
                    model.ExistingProfileImageUrl = existingUser.ExistingProfileImageUrl;
                }

                // Kullanıcıyı güncelliyoruz
                await _userService.UpdateUserAsync(model);
                return RedirectToAction("Profile", new { id = model.Id });
            }

            // Eğer ModelState geçerli değilse, hataları kontrol edin
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            // Hataları gözlemleyebilmek için formu tekrar gösterin
            return View(model);
        }


        // POST: /User/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction(nameof(Register)); // Profil silindikten sonra kullanıcı kaydolma sayfasına yönlendirilir.
        }

        // POST: /User/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectTopics(Guid[] selectedTopics)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null || !selectedTopics.Any())
            {
                return BadRequest();
            }

            await _userTopicService.FollowTopicsAsync(Guid.Parse(userId), selectedTopics);

            
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Ok();
            }

            return RedirectToAction("Profile", "User", new { id = userId }); 
        }
    }

}
