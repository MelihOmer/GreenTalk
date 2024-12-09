using GreenTalk.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GreenTalk.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                new User() { Id = Guid.Parse("E56F6D4C-B396-42D3-BDD5-109E1D519AA4"), Email = "melih@mail.com", Username = "melih.kamar", PasswordHash = "123456" },
                new User() { Id = Guid.Parse("C792249F-DB81-4CF6-99A8-614720E9250D"), Email = "tugba@mail.com", Username = "tugba.kamar", PasswordHash = "654321" });


            base.OnModelCreating(modelBuilder);
        }
    }
}
