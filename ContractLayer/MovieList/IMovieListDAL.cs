using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IMovieListDAL
    {
        void Update(MovieListDTO movieListDTO);
        bool RemoveMovieFromList(int movieId, int movieListId);
        bool AddMovieToList(int movieListId, int movieId);
    }
}
