using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MilliganNathaniel413Assignment3.Models;

namespace MilliganNathaniel413Assignment3.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieDbContext _context;

        //constructor
        public EFMovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public IQueryable<Movie> Movies => _context.Movies;

        //methods required by IMovieRepository interface
        public void AddMovie(Movie movie)
        {
            _context.Add(movie);
            _context.SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            _context.Remove(movie);
            _context.SaveChanges();
        }

        public void EditMovie(Movie movie)
        {
            _context.SaveChanges();
        }
    }
}
