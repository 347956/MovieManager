using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using MovieManager_TeunBuis.Models;
using ContractLayer;

namespace MovieManager_TeunBuis.Controllers
{
    public class MovieController : Controller
    {
        MovieCollection movieCollectionBLL = new MovieCollection();
        public IActionResult Index()
        {
            List<MovieModel> movieModels = new List<MovieModel>();
            foreach (Movie movie in movieCollectionBLL.GetAllMovies())
            {
                movieModels.Add(CreateMovieModelFromMovieBO(movie));
            }
            return View(movieModels);
        }
        public IActionResult AddMovie()
        {
            return View();
        }
        public IActionResult EditMovie(int id)
        {
            MovieModel movieModel = CreateMovieModelFromMovieBO(movieCollectionBLL.GetMovie(id));
            return View(movieModel); 
        }
        public IActionResult DeleteMovie(int id)
        {
            MovieModel movieModel = CreateMovieModelFromMovieBO(movieCollectionBLL.GetMovie(id));
            return View(movieModel);
        }
        [HttpPost]
        public IActionResult AddMovie(MovieModel movieModel)
        {
            movieCollectionBLL.CreateMovie(CreateDTOFromViewModel(movieModel));
            return View();
        }
        [HttpPost]
        public IActionResult EditMovie(MovieModel movieModel)
        {
            Movie movie = new Movie(CreateDTOFromViewModel(movieModel));
            movie.UpdateMovie(CreateDTOFromViewModel(movieModel));
            return View();
        }
        [HttpPost]
        public IActionResult DeleteMovie(MovieModel movieModel)
        {
            MovieListCollection movieListColl = new MovieListCollection();
            movieCollectionBLL.DeleteMovie(movieModel.ID);
            movieListColl.RemoveMovieFromAllLists(movieModel.ID);
            return View();
        }

        //this method converts a Movie BO into a MovieModel
        private MovieModel CreateMovieModelFromMovieBO(Movie movie)
        {
            MovieModel movieModel = new MovieModel();
            movieModel.Name = movie.Name;
            movieModel.Genre = movie.Genre;
            movieModel.GenreTwo = movie.GenreTwo;
            movieModel.Date = movie.Date;
            movieModel.Watched = movie.Watched;
            movieModel.ID = movie.ID;
            return movieModel;
        }
        //this method converts a MovieModel into a MovieDTO
        private MovieDTO CreateDTOFromViewModel(MovieModel movieModel)
        {
            MovieDTO movieDTO = new MovieDTO();
            movieDTO.Name = movieModel.Name;
            movieDTO.Genre = movieModel.Genre;
            movieDTO.GenreTwo = movieModel.GenreTwo;
            movieDTO.Date = movieModel.Date;
            movieDTO.Watched = movieModel.Watched;
            movieDTO.ID = movieModel.ID;
            return movieDTO;
        }
    }
}
