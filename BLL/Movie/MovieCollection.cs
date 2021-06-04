using System;
using FactoryDAL;
using ContractLayer;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MovieCollection
    {
        IMovieCollectionDAL movieCollectionDAL;
        //constructor
        public MovieCollection()
        {
            this.movieCollectionDAL = FactoryMovieDAL.CreateMovieCollectionDAL();
        }
        public MovieCollection(IMovieCollectionDAL movieCollectionDAL)
        {
            this.movieCollectionDAL = movieCollectionDAL;
        }

        //methds
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
        //DTO?
        public void CreateMovie(MovieDTO movieDTO)
        {
            movieCollectionDAL.CreateMovie(movieDTO);
        }
        public void DeleteMovie(int ID)
        {
            movieCollectionDAL.DeleteMovie(ID);
        }
    }
}
