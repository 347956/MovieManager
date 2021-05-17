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
        public List<Movie> Movies { get; set; }
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
        public void AddMovieToList(MovieListDTO movieListDTO)
        {
            if(CheckIfMovieIsAllreadyAdded(moviesIds, movieListDTO.Id) == true)
            {
                movieListDAL.AddMovieToList(movieListDTO.Id, movieListDTO.UserId);   
            }            
        }
        //checks if the movie id is not already present in the list of movie ids
        private bool CheckIfMovieIsAllreadyAdded(List<int> presentMovies, int movieId)
        {
            bool isPresent = false;
            foreach(int presentMovieId in presentMovies)
            {
                if(presentMovieId == movieId)
                {
                    isPresent = true;
                    break;
                }
            }
            return isPresent;
        }
    }
}
