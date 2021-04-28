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
            movieList.moviesInList = GetMoviesFromMovieBLL(movieListCollDall.GetAllMovieListMoviesIDs(movieList.Id));
            return movieList;
        }
        public List<MovieList> GetAllMovieLists()
        {
            List<MovieList> movieLists = new List<MovieList>();
            foreach (MovieListDTO movieListDTO in movieListCollDall.GetAllMovieLists())
            {
                MovieList movieList = new MovieList(movieListDTO);
                movieList.moviesInList = GetMoviesFromMovieBLL(movieListCollDall.GetAllMovieListMoviesIDs(movieList.Id));
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
                movieList.moviesInList = GetMoviesFromMovieBLL(movieListCollDall.GetAllMovieListMoviesIDs(movieList.Id));
                movieLists.Add(movieList);
            }
            return movieLists;
        }
        public void DeleteMovieList(int Id)
        {
            movieListCollDall.DeleteMovieList(Id);
        }
        private List<Movie> GetMoviesFromMovieBLL(List<int> movieIds)
        {
            MovieCollection movieCollection = new MovieCollection();
            List<Movie> movies = new List<Movie>();
            foreach (int id in movieIds)
            {
                Movie movie = movieCollection.GetMovie(id);
                movies.Add(movie);
            }
            return movies;
        }
    }
}
