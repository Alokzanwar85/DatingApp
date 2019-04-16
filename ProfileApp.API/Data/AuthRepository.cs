using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProfileApp.API.Models;

namespace ProfileApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        public DataContext _context { get; set; }

        public AuthRepository(DataContext context)
        {
            _context=context;
        }
        public async Task<User> Login(string username, string password)
        {
            byte[] passwordHash,passwordSalt;
            CreatePasswordHash(password,out passwordHash,out passwordSalt);
           var user=await this._context.Users.FirstOrDefaultAsync(x=>x.UserName==username);
           if(user==null)
           return null;
           
           if(!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
           return null;

           return user;

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i=0;i<computedHash.Length;i++)
                {
                    if(computedHash[i]!=passwordHash[i]) return false;
                    
                }
            }
            return true;
            
        }

        private void ValidateUser(string password)
        {
           
        }

        public async Task<User> Register(User user, string Password)
        {
            byte[] passwordHash,passwordSalt;
            CreatePasswordHash(Password,out passwordHash,out passwordSalt);
            user.PasswordHash=passwordHash;
            user.PasswordSalt=passwordSalt;
            await this._context.AddAsync(user);
            await this._context.SaveChangesAsync();
            return user;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash,out byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512())
            {

                passwordSalt=hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExist(string userName)
        {
            if(await _context.Users.AnyAsync(u=>u.UserName==userName))
            return true;

            return false;
        }

        
    }
}