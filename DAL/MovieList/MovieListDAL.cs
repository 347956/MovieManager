using ContractLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class MovieListDAL : IMovieListDAL, IMovieListCollectionDAL
    {
        public int CreateMovieList(MovieListDTO movieListDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovieList(int Id)
        {
            throw new NotImplementedException();
        }

        public List<MovieListDTO> GetAllMovieListByUserId(int UserId)
        {
            throw new NotImplementedException();
        }

        public MovieListDTO GetMovieList(int Id)
        {
            throw new NotImplementedException();
        }

        public List<MovieListDTO> GetMovieList()
        {
            throw new NotImplementedException();
        }

        public void Update(MovieListDTO movieListDTO)
        {
            throw new NotImplementedException();
        }
    }
}
