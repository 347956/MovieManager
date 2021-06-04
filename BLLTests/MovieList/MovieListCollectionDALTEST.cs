using System;
using System.Collections.Generic;
using System.Text;
using ContractLayer;

namespace BLLTests.MovieList
{
    public class MovieListCollectionDALTEST : IMovieListDAL, IMovieListCollectionDAL
    {
        public void AddMovieToList(int movieListId, int movieId)
        {
            throw new NotImplementedException();
        }

        public int CreateMovieList(MovieListDTO movieListDTO)
        {
            MovieListDTO movieList = new MovieListDTO();
            movieList = movieListDTO;
            return movieList.Id;
        }

        public void DeleteMovieList(int Id)
        {
            throw new NotImplementedException();
        }

        public List<MovieListDTO> GetAllMovieListByUserId(int UserId)
        {
            List<MovieListDTO> movieListDTOsInDataBase = new List<MovieListDTO>();
            List<MovieListDTO> retrievedMovieListDTOs = new List<MovieListDTO>();
            MovieListDTO movieListDTO1 = new MovieListDTO();
            MovieListDTO movieListDTO2 = new MovieListDTO();
            MovieListDTO movieListDTO3 = new MovieListDTO();
            //set some names and id
            movieListDTO1.Name = "TestList1";
            movieListDTO1.Id = 1;
            movieListDTO1.UserId = 1;
            movieListDTO2.Name = "TestList2";
            movieListDTO2.Id = 2;
            movieListDTO2.UserId = 1;
            movieListDTO3.Name = "TestList3";
            movieListDTO3.Id = 3;
            movieListDTO3.UserId = 2;
            //add them to the list
            movieListDTOsInDataBase.Add(movieListDTO1);
            movieListDTOsInDataBase.Add(movieListDTO2);
            movieListDTOsInDataBase.Add(movieListDTO3);
            foreach (MovieListDTO movieListDTO in movieListDTOsInDataBase)
            {
                if(movieListDTO.UserId == UserId)
                {
                    retrievedMovieListDTOs.Add(movieListDTO);
                }
            }
            return retrievedMovieListDTOs;
        }

        public List<int> GetAllMovieListMoviesIDs(int movieListId)
        {
            List<int> movieIds = new List<int>();
            movieIds.Add(1);
            movieIds.Add(2);
            movieIds.Add(3);
            movieIds.Add(4);
            movieIds.Add(5);
            return movieIds;
        }

        public List<MovieListDTO> GetAllMovieLists()
        {
            List <MovieListDTO> movielistDTOs = new List<MovieListDTO>();
            MovieListDTO movieListDTO1 = new MovieListDTO();
            MovieListDTO movieListDTO2 = new MovieListDTO();
            MovieListDTO movieListDTO3 = new MovieListDTO();
            movieListDTO1.Name = "TestList1";
            movieListDTO1.Id = 1;
            movieListDTO1.UserId = 1;
            movieListDTO2.Name = "TestList2";
            movieListDTO2.Id = 2;
            movieListDTO2.UserId = 1;
            movieListDTO3.Name = "TestList3";
            movieListDTO3.Id = 3;
            movieListDTO3.UserId = 2;
            movielistDTOs.Add(movieListDTO1);
            movielistDTOs.Add(movieListDTO2);
            movielistDTOs.Add(movieListDTO3);
            return movielistDTOs;
        }

        public MovieListDTO GetMovieList(int Id)
        {
            int moviestoAdd = 10;
            MovieListDTO movieListDTO = new MovieListDTO();
            movieListDTO.Name = "Test movieListDTO";
            movieListDTO.Id = 1;
            movieListDTO.UserId = 1;
            List <MovieDTO> movieDTOs= new List<MovieDTO>();
            for (int i = 0; i < moviestoAdd; i++)
            {
                MovieDTO movieDTO = new MovieDTO();
                movieDTO.Name = $"MovieDTOTest{i}";
                movieDTO.ID = i;
                movieDTOs.Add(movieDTO);
            }
            movieListDTO.Movies = movieDTOs;
            return movieListDTO;
        }

        public void RemoveMovieFromAllLists(int movieId)
        {
            throw new NotImplementedException();
        }

        public void RemoveMovieFromList(int movieId, int movieListId)
        {
            throw new NotImplementedException();
        }

        public void Update(MovieListDTO movieListDTO)
        {
            throw new NotImplementedException();
        }
    }
}
