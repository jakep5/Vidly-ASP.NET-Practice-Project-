using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek!"
            };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        [Route("movies/ListMovies")]
        public ActionResult ListMovies()
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Name = "Shrek"
                },
                new Movie
                {
                    Id = 2,
                    Name = "Wall-e"
                }
            };

            if (movies.Count == 0)
            {
                return View();
            }
            else
            {
                var viewModel = new MovieListViewModel
                {
                    Movies = movies
                };

                return View(viewModel);
            }
        }
        [Route("movies/details/{id:range(1,2)}")]
        public ActionResult ShowMovie(int id)
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Name = "Shrek"
                },
                new Movie
                {
                    Id = 2,
                    Name = "Wall-e"
                }
            };

            Movie matchingMovie = movies[0];

            foreach (Movie mov in movies)
            {
                if (mov.Id == id)
                {
                    matchingMovie = mov;
                }
            };

            var viewModel = new IndividualMovieViewModel
            {

                Name = matchingMovie.Name,
                id = matchingMovie.Id
            };

            return View(viewModel);
        }
    }
}