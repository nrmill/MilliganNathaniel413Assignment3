using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MilliganNathaniel413Assignment3.Models
{
    public class SeedData
    {
        //seeds data used for testing
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            MovieDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<MovieDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Movies.Any())
            {
                context.Movies.Add(
                    new Movie
                    {
                        Category = "Comedy",
                        Title = "Yeehaw Town",
                        Year = 2021,
                        Director = "Spencer Hilton",
                        Rating = "PG",
                    }
                );

                context.SaveChanges();
            }

        }
    }
}
