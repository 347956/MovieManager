using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IMovieCollectionDAL
    {
        int CreateMovie(MovieDTO movieDTO);
        MovieDTO GetMovie(int ID);
        List<MovieDTO> GetALLMovies();
        void DeleteMovie (int ID);
    }
}
