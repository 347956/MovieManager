using ContractLayer;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryDAL
{
    public static class FactoryMovieListDAL
    {
        public static IMovieListDAL CreateMovieListDAL()
        {
            return new MovieListDAL();
        } 
        public static IMovieListCollectionDAL CreateMovieListCollectionDAL()
        {
            return new MovieListDAL();
        }
    }
}
