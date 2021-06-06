using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using ContractLayer;
using DAL;
using System.Collections.Generic;
using System.Text;
using BLLTests.MovieList;

namespace BLL.Tests
{
    [TestClass()]
    public class MovieListCollectionTests
    {
        [TestMethod()]
        public void GetMovieListTest_RetrieveAMovieListAndCheckIfItContainesMovies_ShouldBeTrue()
        {
            //assign
            //de nep DAL in de test folder
            IMovieListCollectionDAL movieListCollectionDALTest = new MovieListCollectionDALTEST();
            MovieListCollection movieListCollection = new MovieListCollection(movieListCollectionDALTest);
            //act
            MovieList movieList = new MovieList(movieListCollectionDALTest.GetMovieList(1));
            //assert
            Assert.IsTrue(movieList.Movies.Count > 0);
        }
        [TestMethod()]
        public void GetMovieListTest_CheckIfAMovieListCanBeRetrieved_ShouldBeTrue()
        {
            //assign
            IMovieListCollectionDAL movieListCollectionDALTest = new MovieListCollectionDALTEST();
            MovieListCollection movieListCollection = new MovieListCollection(movieListCollectionDALTest);
            //act
            MovieList movieList = new MovieList(movieListCollectionDALTest.GetMovieList(1));
            //assert
            Assert.IsTrue(movieList != null);
        }

        [TestMethod()]
        public void GetAllMovieListsByUserIdTest_RetrieveUserListsById_ShouldReturnTrue()
        {
            //assign
            IMovieListCollectionDAL movieListCollectionDALTest = new MovieListCollectionDALTEST();
            MovieListCollection movieListCollection = new MovieListCollection(movieListCollectionDALTest);
            //act
            List<MovieList> movieListByUserId = movieListCollection.GetAllMovieListsByUserId(1);
            //assert
            //there should be 2 movielists with the user id 2
            Assert.IsTrue(movieListByUserId.Count == 2);
        }

        [TestMethod()]
        public void GetAllMovieListsTest_GetAllMovieListsFromDAL_ShouldReturnTrue()
        {
            //assign
            IMovieListCollectionDAL movieListCollectionDALTest = new MovieListCollectionDALTEST();
            MovieListCollection movieListCollection = new MovieListCollection(movieListCollectionDALTest);
            //act
            List<MovieList> movieListsFromDAL = movieListCollection.GetAllMovieLists();
            //assert
            //there should be 2 movielists with the user id 2
            Assert.IsTrue(movieListsFromDAL.Count > 1);
        }

        [TestMethod()]
        public void CreateMovieListTest_CreateAMovieListAndCheckIfAnIdIsReturned_ShouldBeTrue()
        {
            //assign
            IMovieListCollectionDAL movieListCollectionDALTest = new MovieListCollectionDALTEST();
            MovieListCollection movieListCollection = new MovieListCollection(movieListCollectionDALTest);
            MovieListDTO movieListDTO = new MovieListDTO();
            movieListDTO.Id = 777;
            int movieListId;
            //act
            movieListId = movieListCollection.CreateMovieList(movieListDTO);
            //assert
            Assert.IsTrue(movieListId == movieListDTO.Id);
        }
    }
}