using System.Collections.Generic;
using System.IO;
using ProfileApp.API.Models;

namespace ProfileApp.API.Data
{
    public class Seed
    {
        public DataContext _context { get; set; }

        public Seed(DataContext context)
        {
            _context=context;
        }

        public  void SeedUser()
        {
            var data= File.ReadAllText(@"C:\Users\Alok\Downloads\UserSeedData.json");
            var users=Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(data);

            foreach (var item in users)
            {
                byte[] passwordHash,passwordSalt;
                CreatePasswordHash("password",out passwordHash,out passwordSalt);
                item.PasswordHash=passwordHash;
                item.PasswordSalt=passwordSalt;
                
                _context.Add(item);
            }

            _context.SaveChanges();
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash,out byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512())
            {

                passwordSalt=hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}