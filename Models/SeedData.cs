using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment9.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            MovieDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MovieDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Movies.Any())
            {
                context.Movies.AddRange(
                    //add in seed data
                    new Movie
                    {
                        Title = "Batman",
                        Category = "Action/Adventure",
                        Year = 1989,
                        Director = "Tim Burton",
                        Rating = "PG-13",
                        Notes = null,
                        Lentto = null,
                        Edited = false
                    }
                    
                    );
                context.SaveChanges();
            }
        }
    }
}
