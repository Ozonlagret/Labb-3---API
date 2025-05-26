using Labb_3___API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;

namespace Labb_3___API.Data
    
{
    public class AppDbContext : DbContext
    {
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonInterest>()
                    .HasKey(pi => new { pi.PersonId, pi.InterestId });

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestId);

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Anna Svensson", Phone = "0701234567" },
                new Person { Id = 2, Name = "Erik Karlsson", Phone = "0737654321" }
            );

            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Fotografi", Description = "Att ta bilder och redigera dem" },
                new Interest { Id = 2, Title = "Programmering", Description = "Att skriva kod i olika språk" },
                new Interest { Id = 3, Title = "Matlagning", Description = "Laga nya och spännande rätter" }
            );

            modelBuilder.Entity<PersonInterest>().HasData(
                new PersonInterest { PersonId = 1, InterestId = 1 },
                new PersonInterest { PersonId = 1, InterestId = 2 },
                new PersonInterest { PersonId = 2, InterestId = 2 },
                new PersonInterest { PersonId = 2, InterestId = 3 }
            );

            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, Url = "https://www.photographyblog.com", PersonId = 1, InterestId = 1 },
                new Link { Id = 2, Url = "https://www.github.com", PersonId = 1, InterestId = 2 },
                new Link { Id = 3, Url = "https://www.stackoverflow.com", PersonId = 2, InterestId = 2 },
                new Link { Id = 4, Url = "https://www.tasteline.se", PersonId = 2, InterestId = 3 }
            );
        }
    }
}

