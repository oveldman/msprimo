using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;
using Website.Models.Admin;

namespace Website.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IAuthenticationManager _authenticationManager;
        private IEditor _editor;
        private IReader _reader;

        public AdminController(SignInManager<User> signInManager, UserManager<User> userManager, PrimoContext context)
        {
            _authenticationManager = new AuthenticationManager(signInManager, userManager);
            _editor = new Editor(context);
            _reader = new Reader(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            var model = new LoginViewModel();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel account)
        {
            var result = await _authenticationManager.SignIn(account.Email, account.Password);
            return RedirectToAction(result.Succeed ? "Index" : "Login");
        }

        public async Task<IActionResult> Logout()
        {
            var result = await _authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult NewStory()
        {
            var model = new StoryViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult NewStory(StoryViewModel model)
        {
            string message = model.Message;
            var result = _editor.SaveNewStory(message);

            if (result.Succeed)
            {
                return RedirectToAction("Index");
            }

            model.Warning = result.ErrorMessages[0];
            return View(model);
        }

        public IActionResult EditStory(string id)
        {
            var model = new StoryViewModel();
            model.Stories = new List<Story>();
            model.Stories.Add(_reader.GetStory(id));
            return View(model);
        }

        [HttpPost]
        public IActionResult EditStory(StoryViewModel model)
        {
            var result = _editor.EditStory(model.Stories[0]);

            if (result.Succeed)
            {
                return RedirectToAction("Index", "Home");
            }

            model.Warning = result.ErrorMessages[0];
            return View(model);
        }

        public IActionResult DeleteConfirmStory(string id)
        {
            var model = new StoryViewModel();
            model.Stories = new List<Story>();
            model.Stories.Add(_reader.GetStory(id));
            return View(model);
        }

        public IActionResult DeleteStory(string id)
        {
            var result = _editor.DeleteStory(id);
            return RedirectToAction("Index", "Home");
        }
    }
}