using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IMovieListDAL
    {
        void Update(MovieListDTO movieListDTO);
        bool AddMovieToList(int movieListId, int movieId);
    }
}
