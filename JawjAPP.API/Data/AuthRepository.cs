using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JawjAPP.API.Models;
using Microsoft.EntityFrameworkCore;

namespace JawjAPP.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        DataContext _dataContext;
        public AuthRepository(DataContext dataContext)
        {
            this._dataContext=dataContext;
        }
        public  async Task<User> Login(string username, string pawssword)
        {
          var user= await   _dataContext.users.FirstOrDefaultAsync(x=>x.UserName==username);
            if (user == null) return null;
            if (!VerifyPassword(pawssword,   user.Passwordalt, user.Hashpassword)) return null;
          return   user;
        }

        private bool VerifyPassword(string pawssword, byte[] passwordalt, byte[] passwordHash)
        {
            using( var hmac = new System.Security.Cryptography.HMACSHA256(passwordalt))
            {
               var computedHshPassword= hmac.ComputeHash(Encoding.UTF8.GetBytes(pawssword));
               for (var i=0;i<computedHshPassword.Length;i++){
                    if (computedHshPassword[i]!=passwordHash[i])
                    {
                        return false;
                    }

               }
               return true;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] saltPassword)
        {
            using( var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                saltPassword= hmac.Key;
                passwordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }

        public async Task<User> Register(User user, string password)
        {
             byte[] passwordHash,  saltPassword;//= Encoding.UTF8.GetBytes(pawssword);
            CreatePasswordHash(password, out passwordHash, out saltPassword);
            user.Passwordalt=saltPassword;
            user.Hashpassword=passwordHash;
             await _dataContext.users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;


        }

        public async  Task<bool> UserExists(string username)
        {
            if (await   _dataContext.users.AnyAsync(x=>x.UserName==username)){
                return true;
            }
            return false;
        }
    }
}