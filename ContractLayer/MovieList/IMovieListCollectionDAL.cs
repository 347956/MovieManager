using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IMovieListCollectionDAL
    {
        int CreateMovieList(MovieListDTO movieListDTO);
        MovieListDTO GetMovieList(int Id);
        List<MovieListDTO> GetMovieList();
        List<MovieListDTO> GetAllMovieListByUserId(int UserId);
        void DeleteMovieList(int Id);
    }
}
