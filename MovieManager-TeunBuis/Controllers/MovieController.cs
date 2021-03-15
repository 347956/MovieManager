using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using MovieManager_TeunBuis.Models;

namespace MovieManager_TeunBuis.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            List<MovieModel> movieModels = new List<MovieModel>();
            foreach (Movie movie in new MovieCollection().GetAllMovies())
            {
                movieModels.Add(new MovieModel { Name = movie.Name, Genre = movie.Genre, GenreTWo = movie.GenreTwo, Date = movie.Date, Watched = movie.Watched, ID = movie.ID });
            }
            ViewBag.movies = movieModels;
            return View();
        }
        public IActionResult MovieList()
        {
            return View();
        }
    }
}
