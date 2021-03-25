using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MilliganNathaniel413Assignment3.Models;

namespace MilliganNathaniel413Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //connection to database
        private IMovieRepository _repository;

        public HomeController(ILogger<HomeController> logger, IMovieRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                //Add new movie, update database

                _repository.AddMovie(newMovie);

                return View("MovieList", _repository.Movies);
            }
            else
            {
                return View();
            }

        }

        //display table of all movies (added 'edit' and 'delete' buttons 
        public IActionResult MovieList()
        {
            return View(_repository.Movies);
        }

        //Grabs the correct movie from what the user picked and uses that to populate the fields in edit view
        public IActionResult EditMovie(int movieID)
        {
            Movie movie = _repository.Movies.Where(m => m.MovieID == movieID).FirstOrDefault();

            return View(movie);
        }

        //Updates the movie, saves to database, redirects user to movie list
        [HttpPost]
        public IActionResult EditMovie(Movie movie, int movieID)
        {
            _repository.Movies.Where(m => m.MovieID == movieID).FirstOrDefault().Category = movie.Category;
            _repository.Movies.Where(m => m.MovieID == movieID).FirstOrDefault().Title = movie.Title;
            _repository.Movies.Where(m => m.MovieID == movieID).FirstOrDefault().Year = movie.Year;
            _repository.Movies.Where(m => m.MovieID == movieID).FirstOrDefault().Director = movie.Director;
            _repository.Movies.Where(m => m.MovieID == movieID).FirstOrDefault().Rating = movie.Rating;
            _repository.Movies.Where(m => m.MovieID == movieID).FirstOrDefault().Edited = movie.Edited;
            _repository.Movies.Where(m => m.MovieID == movieID).FirstOrDefault().LentTo = movie.LentTo;
            _repository.Movies.Where(m => m.MovieID == movieID).FirstOrDefault().Notes = movie.Notes;
            _repository.EditMovie(movie);
            return RedirectToAction("MovieList");
        }


        //deletes movie in database, redirects user to movie list
        [HttpPost]
        public IActionResult DeleteMovie(int movieID)
        {
            Movie movie = _repository.Movies.Where(m => m.MovieID == movieID).FirstOrDefault();
            _repository.DeleteMovie(movie);
            return RedirectToAction("MovieList");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
