using BLL;
using ContractLayer;
using Microsoft.AspNetCore.Mvc;
using MovieManager_TeunBuis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager_TeunBuis.Controllers
{
    public class MovieListController : Controller
    {
        MovieListCollection movieListCollection = new MovieListCollection();
        MovieCollection movieCollection = new MovieCollection();
        public IActionResult Index(int userId)
        {
            List<MovieListModel> movieListModels = new List<MovieListModel>();
            foreach(MovieList movielist in movieListCollection.GetAllMovieListsByUserId(userId))
            {
                movieListModels.Add(MovieListModelFromBO(movielist));
            }
            return View(movieListModels);
        }
        public IActionResult MovieListDetails(int movieListId)
        {
            MovieListModel movieListModel = MovieListModelFromBO(movieListCollection.GetMovieList(movieListId));
            movieListModel.movieModels = GetMoviesForMovieList(movieListModel.movieIds);
            return View(movieListModel);
        }
        public IActionResult EditMovieList(int movieListId)
        {
            MovieListModel movieListModel = MovieListModelFromBO(movieListCollection.GetMovieList(movieListId));
            return View(movieListModel);
        }
        public IActionResult AddMovieToList()
        {
            List<MovieModel> movieModels = new List<MovieModel>();
            foreach (Movie movie in movieCollection.GetAllMovies())
            {
                movieModels.Add(CreateMovieModelFromMovieBO(movie));
            }
            return View(movieModels);
        }
        [HttpPost]
        public IActionResult EditMovieList(MovieListModel movieListModel)
        {
            MovieList movie = new MovieList(CreateMovieListDTOFromViewModel(movieListModel));
            movie.Update(CreateMovieListDTOFromViewModel(movieListModel));
            return RedirectToAction("Index", "MovieList");
        }
        [HttpPost]
        public void MovieListDeleteMovie(int movieId, int movieListID)
        {
            movieListCollection.RemoveMovieFromList(movieListID, movieId);
        }
        private MovieListDTO CreateMovieListDTOFromViewModel(MovieListModel movieListModel)
        {
            MovieListDTO movieListDTO = new MovieListDTO();
            movieListDTO.Id = movieListModel.Id;
            movieListDTO.UserId = movieListModel.UserId;
            movieListDTO.MovieCount = movieListModel.MovieCount;
            movieListDTO.Name = movieListModel.Name;
            return movieListDTO;
        }
        private List<MovieModel> GetMoviesForMovieList(List<int> movieIds)
        {
            List<MovieModel> movies = new List<MovieModel>();
            foreach(int id in movieIds)
            {
                Movie movie = movieCollection.GetMovie(id);
                movies.Add(CreateMovieModelFromMovieBO(movie));
            }
            return movies;
        }
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
        private MovieListModel MovieListModelFromBO(MovieList movieList)
        {
            MovieListModel movieListModel = new MovieListModel();
            movieListModel.Id = movieList.Id;
            movieListModel.Name = movieList.Name;
            movieListModel.MovieCount = movieList.MovieCount;
            movieListModel.movieIds = movieList.moviesIds;
            movieListModel.UserId = movieList.UserId;
            return movieListModel;
        }
    }
}
