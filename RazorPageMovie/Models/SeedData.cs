using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;

namespace RazorPageMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPageMovieContext>>()))
            {
                if(context == null || context.Movie == null)
                {
                    throw new ArgumentException("Null razorPageMovieContext");
                }

                if (context.Movie.Any())
                {
                    return;
                }

                context.AddRange(
                    new Movie
                    {
                        Title = "Ghostbusters",
                        Gender = "Comedy",
                        price = 8.99M,
                        RekeaseDate = DateTime.Parse("1989-2-10"),
                        Raiting = "R"
                    },
                    new Movie
                    {
                        Title = "The Lord Of The Rings",
                        Gender = "Comedy",
                        price = 8.99M,
                        RekeaseDate = DateTime.Parse("1989-2-10"),
                        Raiting = "G"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
