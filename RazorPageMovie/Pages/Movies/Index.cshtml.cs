using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;
using RazorPageMovie.Models;

namespace RazorPageMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovie.Data.RazorPageMovieContext _context;

        public IndexModel(RazorPageMovie.Data.RazorPageMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? searchString { get; set; }
        public SelectList? Gender { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MoviesGenders { get; set; }

        public async Task OnGetAsync()
        {

            IQueryable<string> genderQuery = from m in _context.Movie
                                             orderby m.Gender
                                             select m.Gender;

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.Contains(searchString));
                Movie = movies.ToList();
            }

            if (!string.IsNullOrEmpty(MoviesGenders))
            {
                movies = movies.Where(x => x.Gender == MoviesGenders);
                Movie = movies.ToList();

            }

            if (_context.Movie != null)
            {
                Gender = new SelectList(await genderQuery.Distinct().ToListAsync());
                Movie = await _context.Movie.ToListAsync();
            }

        }
    }
}
