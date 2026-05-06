using CP2_VetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CP2_VetApi.Data
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

