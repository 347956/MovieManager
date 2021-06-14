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
        UserCollection userCollection = new UserCollection();
        public IActionResult Index(string userName)
        {
            if (userName == null)
            {
                return RedirectToAction("Woops", "Home");
            }
            int userId = userCollection.GetUserIdByUName(userName);
            List<MovieListModel> movieListModels = new List<MovieListModel>();
            foreach(MovieList movielist in movieListCollection.GetAllMovieListsByUserId(userId))
            {
                movieListModels.Add(MovieListModelFromBO(movielist));
            }
            return View(movieListModels);
        }
        public IActionResult MovieListDetails(int movieListId)
        {
            if (movieListId == 0)
            {
                return RedirectToAction("Woops", "Home");
            }
            MovieListModel movieListModel = MovieListModelFromBO(movieListCollection.GetMovieList(movieListId));
            movieListModel.movieModels = GetMoviesForMovieList(movieListModel.movieIds);
            return View(movieListModel);
        }
        public IActionResult EditMovieList(int movieListId)
        {
            if (movieListId == 0)
            {
                return RedirectToAction("Woops", "Home");
            }
            MovieListModel movieListModel = MovieListModelFromBO(movieListCollection.GetMovieList(movieListId));
            return View(movieListModel);
        }
        public IActionResult DeleteMovieFromList(int movieId, int movieListId)
        {
            if (movieListId == 0 || movieId == 0)
            {
                return RedirectToAction("Woops", "Home");
            }
            MovieModel movieModel = CreateMovieModelFromMovieBO(movieCollection.GetMovie(movieId));
            TempData["movieListId"] = movieListId;
            return View(movieModel);
        }

        public IActionResult AddMovieToList(int movieListId)
        {
            if (movieListId == 0)
            {
                return RedirectToAction("Woops", "Home");
            }
            MovieListModel movieListModel = MovieListModelFromBO(movieListCollection.GetMovieList(movieListId));
            List<MovieModel> movieModels = new List<MovieModel>();
            foreach (Movie movie in movieCollection.GetAllMovies())
            {
                if(CheckIfMovieIsAlreadyInList(movie, movieListModel) == false)
                {
                    movieModels.Add(CreateMovieModelFromMovieBO(movie));
                }                
            }
            TempData["movielistId"] = movieListId;
            return View(movieModels);
        }
        public IActionResult CreateMovieList()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMovieList(MovieListModel movieListModel, string userName)
        {
            int userId = userCollection.GetUserIdByUName(userName);
            movieListModel.UserId = userId;
            movieListCollection.CreateMovieList(CreateMovieListDTOFromViewModel(movieListModel));
            return RedirectToAction("Index", "MovieList");
        }
        [HttpPost]
        public IActionResult AddMovieToList(int movieId, int movieListId)
        {
            MovieListModel movieListModel = MovieListModelFromBO(movieListCollection.GetMovieList(movieListId));
            MovieListDTO movieListDTO = CreateMovieListDTOFromViewModel(movieListModel);
            MovieList movieList = new MovieList(movieListDTO);           
            movieList.AddMovieToList(movieListDTO, movieId);
            return RedirectToAction("EditMovieList", new { movieListId = movieListId });
        }

        [HttpPost]
        public IActionResult EditMovieList(MovieListModel movieListModel)
        {
            MovieList movie = new MovieList(CreateMovieListDTOFromViewModel(movieListModel));
            movie.Update(CreateMovieListDTOFromViewModel(movieListModel));
            return RedirectToAction("Index", "MovieList");
        }
        [HttpPost]
        public IActionResult MovieListDeleteMovie(int movieId, int movieListID)
        {
            MovieList movieList = movieListCollection.GetMovieList(movieListID);
            MovieListDTO movieListDTO = movieListDTOFromMovieBO(movieList);
            movieList.RemoveMovieFromList(movieListID, movieId, movieListDTO);
            return RedirectToAction("MovieListDetails", "MovieList", movieListID);
        }

        private bool CheckIfMovieIsAlreadyInList(Movie movie, MovieListModel movieListModel)
        {
            bool isPresent = false;
            foreach(MovieModel movieModel in movieListModel.movieModels)
            {
                if(movieModel.ID == movie.ID)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;

        }
        private MovieListDTO CreateMovieListDTOFromViewModel(MovieListModel movieListModel)
        {
            MovieListDTO movieListDTO = new MovieListDTO();
            movieListDTO.Id = movieListModel.Id;
            movieListDTO.UserId = movieListModel.UserId;
            movieListDTO.MovieCount = movieListModel.MovieCount;
            movieListDTO.Name = movieListModel.Name;
            foreach(MovieModel moviemodel in movieListModel.movieModels)
            {
                movieListDTO.Movies.Add(movieDTOFromMovieModel(moviemodel));
            }
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
            movieListModel.movieModels = GetMovieModelsListFromBO(movieList.Movies);
            return movieListModel;
        }
        private List<MovieModel> GetMovieModelsListFromBO(List<Movie> moviesBOList)
        {
            List<MovieModel> movieModels = new List<MovieModel>();
            foreach(Movie movie in moviesBOList)
            {
                movieModels.Add(CreateMovieModelFromMovieBO(movie));
            }
            return movieModels;
        }
        private MovieListDTO movieListDTOFromMovieBO(MovieList movieList)
        {
            MovieListDTO movieListDTO = new MovieListDTO();
            movieListDTO.Name = movieList.Name;
            movieListDTO.Id = movieList.Id;
            movieListDTO.UserId = movieList.UserId;
            movieListDTO.MovieCount = movieList.MovieCount;
            return movieListDTO;
        }
        private MovieDTO movieDTOFromMovieModel(MovieModel movieModel)
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
