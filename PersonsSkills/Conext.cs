using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonsSkills.Models;

namespace PersonsSkills
{
    public class Conext : IdentityDbContext<IdentityUser>
    {
        public Conext(DbContextOptions options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Skill> Skills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Person>()
                .HasMany(e => e.Skills)
                .WithOne()
                .OnDelete(DeleteBehavior.ClientCascade);
           
        }

    }
}


