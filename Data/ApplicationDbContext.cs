
using Microsoft.EntityFrameworkCore;
using dotnet.Models;

namespace dotnet.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Student> Students {get;set;}
        public DbSet<Book> Books{get;set;}

        public DbSet<Teacher> Teachers { get; set; }
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options )
          :base(options)
         {
         }

      
    }

   
    
}