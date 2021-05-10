using BLL;
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
                movieListModels.Add(movieListModelFromBO(movielist));
            }
            return View(movieListModels);
        }
        public IActionResult MovieListDetails(int movieListId)
        {
            MovieListModel movieListModel = movieListModelFromBO(movieListCollection.GetMovieList(movieListId));
            movieListModel.movieModels = GetMoviesForMovieList(movieListModel.movieIds);
            return View(movieListModel);
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
        private MovieListModel movieListModelFromBO(MovieList movieList)
        {
            MovieListModel movieListModel = new MovieListModel();
            movieListModel.Id = movieList.Id;
            movieListModel.Name = movieList.Name;
            movieListModel.MovieCount = movieList.MovieCount;
            movieListModel.movieIds = movieList.moviesIds;
            return movieListModel;
        }
    }
}
