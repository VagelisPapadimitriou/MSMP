using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MSMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMP.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }


        //Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 4,
                    Title = "The Matrix",
                    ReleaseDate = DateTime.Now,
                    Genre = "SciFi",
                    Duration = 130,
                    Rating = 100,
                    Description = "There is no spoon",
                    ImageUrl = "~/images/dark skies.jpg"
                },
                new Movie
                {
                    MovieId = 7,
                    Title = "Spider-Man",
                    ReleaseDate = DateTime.Now,
                    Genre = "Action",
                    Duration = 120,
                    Rating = 95,
                    Description = "With great power comes great responsibility",
                    ImageUrl = "~/images/fortune of time.jpg"
                },
                new Movie
                {
                    MovieId = 3,
                    Title = "John Wick",
                    ReleaseDate = DateTime.Now,
                    Genre = "Thriller",
                    Duration = 120,
                    Rating = 95,
                    Description = "Don't provoke him",
                    ImageUrl = "~/images/vanish in the sunset.jpg"
                }
                );
        }
    }
}
