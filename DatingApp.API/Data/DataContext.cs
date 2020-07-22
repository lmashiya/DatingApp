using DatingApp.API.Model;
using DatingApp.API.Properties.Model;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
         optionsBuilder.UseSqlite("Data Source=datingapp.db");
        }
    }

        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }

    }
}