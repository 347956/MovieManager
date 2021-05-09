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
            return View(movieListModel);
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
