using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using ContractLayer;
using DAL;
using System.Collections.Generic;
using System.Text;

namespace BLL.Tests
{
    [TestClass()]
    public class MovieListCollectionTests
    {
        [TestMethod()]
        public void GetMovieListTest()
        {
            //assign
            //nieuwe nep DAl maken, in test map
            IMovieListCollectionDAL movieListCollectionDAL = new MovieListDAL();
            MovieListCollection movieListCollection = new MovieListCollection();
            //act
            //assert
            Assert.Fail();
        }
    }
}