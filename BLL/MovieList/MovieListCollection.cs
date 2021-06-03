using ContractLayer;
using FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MovieListCollection
    {
        IMovieListCollectionDAL movieListCollDall;
        public MovieListCollection()
        {
            movieListCollDall = FactoryMovieListDAL.CreateMovieListCollectionDAL();
        }
        public MovieListCollection(IMovieListCollectionDAL movieCollectionDAL)
        {
            movieListCollDall = movieCollectionDAL;
        }
        public int CreateMovieList(MovieListDTO movieListDTO)
        {
            return movieListCollDall.CreateMovieList(movieListDTO);
        }
        public MovieList GetMovieList(int id)
        {
            MovieList movieList = new MovieList(movieListCollDall.GetMovieList(id));
            movieList.moviesIds = movieListCollDall.GetAllMovieListMoviesIDs(movieList.Id);
            return movieList;
        }
        public List<MovieList> GetAllMovieLists()
        {
            List<MovieList> movieLists = new List<MovieList>();
            foreach (MovieListDTO movieListDTO in movieListCollDall.GetAllMovieLists())
            {
                MovieList movieList = new MovieList(movieListDTO);
                movieList.moviesIds = movieListCollDall.GetAllMovieListMoviesIDs(movieList.Id);
                movieLists.Add(movieList);
            }
            return movieLists;
        }
        public List<MovieList> GetAllMovieListsByUserId(int Id)
        {
            List<MovieList> movieLists = new List<MovieList>();
            foreach(MovieListDTO movieListDTO in movieListCollDall.GetAllMovieListByUserId(Id))
            {
                MovieList movieList = new MovieList(movieListDTO);
                movieList.moviesIds = movieListCollDall.GetAllMovieListMoviesIDs(movieList.Id);
                movieLists.Add(movieList);
            }
            return movieLists;
        }
        public void DeleteMovieList(int Id)
        {
            movieListCollDall.DeleteMovieList(Id);
        }
        //removes a movie from a single list
        public void RemoveMovieFromList(int movieListId, int movieId)
        {
            movieListCollDall.RemoveMovieFromList(movieListId, movieId);
        }
        //removes the movie from all lists(in case the movie itsels will be deleted)
        public void RemoveMovieFromAllLists(int movieListId)
        {
            movieListCollDall.RemoveMovieFromAllLists(movieListId);
        }
    }
}
