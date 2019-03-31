

using System.Threading.Tasks;
using ProfileApp.API.Models;

namespace ProfileApp.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user,string Password);
         Task<User> Login(string username,string password);
         Task<bool> UserExist(string userName);
    }
}