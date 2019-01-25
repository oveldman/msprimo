using System.Threading.Tasks;
using DataLayer;
using DataLayer.Model;
using Microsoft.AspNetCore.Identity;
using Service.Interfaces;

namespace Service
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        
        public AuthenticationManager(SignInManager<User> newSignInManager, UserManager<User>  newUserManager)
        {
            _signInManager = newSignInManager;
            _userManager = newUserManager;
        }

        public async Task<bool> FirstTime()
        {
            var user = new User()
            {
                Email = "test@test.nl",
                UserName = "test@test.nl"
            };

            await SignUp(user, "Test1234!");
            return true;
        }

        public async Task<MSPResult> SignIn(string email,  string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, true);
            return new MSPResult() { Succeed = result.Succeeded };
        }

        public async Task<MSPResult> SignUp(User newUser, string password)
        {
            var result = await _userManager.CreateAsync(newUser, password);
            return new MSPResult() { Succeed = result.Succeeded };
        }

        public async Task<MSPResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return new MSPResult();
        }
    }
}