using System.Threading.Tasks;
using JawjAPP.API.Models;

namespace JawjAPP.API.Data
{
    public interface IAuthRepository
    {
            Task<User> Register(User user, string password);
            Task<User> Login (string username , string pawssword);
            Task<bool> UserExists (string username);
    }
}