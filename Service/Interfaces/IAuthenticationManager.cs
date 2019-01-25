using System.Threading.Tasks;
using DataLayer;
using DataLayer.Model;

namespace Service.Interfaces
{
    public interface IAuthenticationManager
    {
        Task<bool> FirstTime();
        Task<MSPResult> SignIn(string email, string password);
        Task<MSPResult> SignOut();
        Task<MSPResult> SignUp(User newUser, string password);
    }
}