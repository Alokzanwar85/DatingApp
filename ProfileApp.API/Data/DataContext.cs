using Microsoft.EntityFrameworkCore;
using ProfileApp.API.Models;

namespace ProfileApp.API.Data
{
    public class DataContext:DbContext
    {
      public DataContext(DbContextOptions<DataContext> options):base(options)
      {
          
      }  

      public DbSet<Value> Values{get;set;}
    }
}