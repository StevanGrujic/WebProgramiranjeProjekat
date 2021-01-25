using Microsoft.EntityFrameworkCore;

namespace ProjekatBackend.Models
{
    public class RokContext : DbContext
    {
        public DbSet<Amfiteatar> Amfiteatri { get; set; }  
        public DbSet<Ispit> Ispiti { get; set; }
        public DbSet<IspitniRok> IspitniRokovi { get; set; }
        public DbSet<Student> Studenti { get; set; }
        public RokContext(DbContextOptions options):base(options)
        {
            
        }
    }

}