using System;
using ContractLayer;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace FactoryDAL
{
    public static class FactoryMovieDAL
    {
        public static IMovieDAL CreateMovieDAL()
        {
            return new MovieDAL();
        }
        public static IMovieCollectionDAL CreateMovieCollectionDAL()
        {
            return new MovieDAL();
        }
    }
}
