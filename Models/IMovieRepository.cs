using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilliganNathaniel413Assignment3.Models
{
    //create inheritable movie repository interface
    public interface IMovieRepository
    {
        IQueryable<Movie> Movies { get; }

        void AddMovie(Movie movie);
        void DeleteMovie(Movie movie);
        void EditMovie(Movie movie);
    }
}
