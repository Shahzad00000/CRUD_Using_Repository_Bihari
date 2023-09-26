using CRUD_Using_Repository_Bihari.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Using_Repository_Bihari.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
