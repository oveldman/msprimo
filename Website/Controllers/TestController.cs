using System.Threading.Tasks;
using DataLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;
using Website.Migrations;

namespace Website.Controllers
{
    public class TestController : Controller
    {
        private readonly IAuthenticationManager _authenticationManager;
        
        public TestController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _authenticationManager = new AuthenticationManager(signInManager, userManager);
        }
        
        public async Task<IActionResult> Index()
        {
            await _authenticationManager.FirstTime();
            return RedirectToAction("Index", "Home");
        }
    }
}