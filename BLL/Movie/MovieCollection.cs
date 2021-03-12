using System;
using FactoryDAL;
using ContractLayer;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MovieCollection
    {
        IMovieCollectionDAL movieCollectionDAL = FactoryMovieDAL.CreateMovieCollectionDAL();
        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            foreach(MovieDTO movieDTO in movieCollectionDAL.GetALLMovies())
            {
                Movie movie = new Movie(movieDTO);
                movies.Add(movie);
            }
            return movies;
        }
        public Movie GetMovie(int ID)
        {
            Movie movie = new Movie(movieCollectionDAL.GetMovie(ID));
            return movie;
        }
        public void CreateMovie(Movie movie)
        {
            MovieDTO movieDTO = new MovieDTO();
            movieDTO.Name = movie.Name;
            movieDTO.Genre = movie.Genre;
            movieDTO.Date = movie.Date;
            movieDTO.Watched = movie.Watched;
            movieDTO.ID = movie.ID;
            movieCollectionDAL.CreateMovie(movieDTO);
        }
        public void DeleteMovie(int ID)
        {
            movieCollectionDAL.DeleteMovie(ID);
        }
    }
}
