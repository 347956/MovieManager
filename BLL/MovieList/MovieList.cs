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

        public MovieList(MovieListDTO movieListDTO)
        {
            this.Name = movieListDTO.Name;
            this.MovieCount = movieListDTO.MovieCount;
            this.Id = movieListDTO.Id;
            this.UserId = movieListDTO.UserId;
        }
        IMovieListDAL movieListDAL = FactoryMovieListDAL.CreateMovieListDAL();

        public void Update(MovieListDTO movieListDTO)
        {
            movieListDAL.Update(movieListDTO);
        }
        
    }
}
