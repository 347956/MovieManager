using ContractLayer;
using FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MovieListCollection
    {
        IMovieListCollectionDAL movieListCollDall = FactoryMovieListDAL.CreateMovieListCollectionDAL();
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
    }
}
