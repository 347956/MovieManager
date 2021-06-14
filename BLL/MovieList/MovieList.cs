using ContractLayer;
using FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MovieList
    {
        public string Name { get; set; }
        public int MovieCount { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> moviesIds = new List<int>();
        public List<Movie> Movies = new List<Movie>();
        private IMovieListDAL movieListDAL {get; set;}

        //constructor
        public MovieList(MovieListDTO movieListDTO)
        {
            this.Name = movieListDTO.Name;
            this.MovieCount = movieListDTO.MovieCount;
            this.Id = movieListDTO.Id;
            this.UserId = movieListDTO.UserId;
            this.movieListDAL = FactoryMovieListDAL.CreateMovieListDAL();
            foreach(MovieDTO movieDTO in movieListDTO.Movies)
            {
                Movie movie = new Movie(movieDTO);
                Movies.Add(movie);
            }
        }
        //methods
        public void Update(MovieListDTO movieListDTO)
        {
            movieListDAL.Update(movieListDTO);
        }
        public void AddMovieToList(MovieListDTO movieListDTO, int newMovieId)
        {           
            if(CheckIfMovieIsAllreadyPresent(newMovieId, Movies) == false)
            {
                if(movieListDAL.AddMovieToList(movieListDTO.Id, newMovieId) == true)
                {
                    movieListDTO.MovieCount++;
                    Update(movieListDTO);
                }                
            }
        }  
        //removes a movie from a single list
        public void RemoveMovieFromList(int movieListId, int movieId, MovieListDTO movieListDTO)
        {
            if(movieListDAL.RemoveMovieFromList(movieListId, movieId) == true )
            {
                movieListDTO.MovieCount--;
                Update(movieListDTO);
            }
        }
        //checks if the movie id is not already present in the list of movie ids
        private bool CheckIfMovieIsAllreadyPresent(int newMovieId, List<Movie> movies)
        {
            bool isPresent = false;
            foreach(Movie movie in movies)
            {
                if(movie.ID == newMovieId)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }
    }
}
