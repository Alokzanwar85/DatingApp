using System.Collections.Generic;
using System.Threading.Tasks;
using ProfileApp.API.Models;

namespace ProfileApp.API.Data
{
    public interface IUserrepository
    {
         void Add<T>(T entity) where T:class;
         void Delete<T>(T entity) where T:class;
         
         Task<bool> SaveAll();

         Task<IEnumerable<User>> GetUsers();

         Task<User> GetUser(int id);
    }
}