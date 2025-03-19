
using Microsoft.EntityFrameworkCore;

namespace Akilli_Parmaklar.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet'lerini buraya ekle
        public DbSet<Game> Games{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<User>().Property(p => p.Email).IsRequired();
        }
    }
}
