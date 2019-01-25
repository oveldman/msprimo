using System.Threading.Tasks;
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
        
        public AdminController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _authenticationManager = new AuthenticationManager(signInManager, userManager);
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
    }
}