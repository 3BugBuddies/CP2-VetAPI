using CP_dotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNet.API.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<TutorEntity> Tutor { get; set; }

        public DbSet<PetEntity> Pet { get; set; }

    }
}

