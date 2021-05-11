using ContractLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class MovieListDAL : IMovieListDAL, IMovieListCollectionDAL
    {
        string connectionString = "Server = mssql.fhict.local; Database=dbi347956;User Id = dbi347956; Password=Teun1701!";
        public int CreateMovieList(MovieListDTO movieListDTO)
        {
            int createdMovieId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO MovieList (Name, MovieCount, UserId)";
                    query += " VALUES (@Name, @MovieCount, @UserId)";
                    query += " SELECT CAST (scope_identity() AS int)";
                    SqlCommand createMovieList = new SqlCommand(query, conn);
                    createMovieList.Parameters.AddWithValue("@Name", movieListDTO.Name);
                    conn.Open();
                    createdMovieId = Convert.ToInt32(createMovieList.ExecuteScalar());
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return createdMovieId;
        }

        public void DeleteMovieList(int Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE * FROM MovieList WHERE Id = @Id";
                    SqlCommand deleteMovieListCommand = new SqlCommand(query, conn);
                    deleteMovieListCommand.Parameters.AddWithValue("@Id", Id);
                    conn.Open();
                    deleteMovieListCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public List<MovieListDTO> GetAllMovieListByUserId(int UserId)
        {

            List<MovieListDTO> movieListDTOs = new List<MovieListDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM MovieList WHERE UserId = @UserId";
                    SqlCommand getMovieListByUserId = new SqlCommand(query, conn);
                    getMovieListByUserId.Parameters.AddWithValue("@UserId", UserId);
                    conn.Open();
                    var reader = getMovieListByUserId.ExecuteReader();
                    while (reader.Read())
                    {
                        MovieListDTO movieListDTO = new MovieListDTO();
                        movieListDTO.Id = reader.GetInt32(0);
                        movieListDTO.Name = reader.GetString(1);
                        movieListDTO.MovieCount = reader.GetInt32(2);
                        movieListDTO.UserId = reader.GetInt32(3);
                        movieListDTOs.Add(movieListDTO);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return movieListDTOs;
        }

        public MovieListDTO GetMovieList(int Id)
        {
            MovieListDTO movieListDTO = new MovieListDTO();
            try
            {                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM MovieList WHERE Id = @Id";
                    SqlCommand getMovieList = new SqlCommand(query, conn);
                    getMovieList.Parameters.AddWithValue("@Id", Id);
                    conn.Open();
                    var reader = getMovieList.ExecuteReader();
                    if (reader.Read())
                    {
                        movieListDTO.Id = reader.GetInt32(0);
                        movieListDTO.Name = reader.GetString(1);
                        movieListDTO.MovieCount = reader.GetInt32(2);
                        movieListDTO.UserId = reader.GetInt32(3);
                    }
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
            return movieListDTO;
        }

        public List<MovieListDTO> GetAllMovieLists()
        {
            List<MovieListDTO> movieListDTOs = new List<MovieListDTO>();
            try
            {                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM MovieList";
                    SqlCommand getAllMovieLists = new SqlCommand(query, conn);
                    conn.Open();
                    var reader = getAllMovieLists.ExecuteReader();
                    while (reader.Read())
                    {
                        MovieListDTO movieListDTO = new MovieListDTO();
                        movieListDTO.Id = reader.GetInt32(0);
                        movieListDTO.Name = reader.GetString(1);
                        movieListDTO.MovieCount = reader.GetInt32(2);
                        movieListDTO.UserId = reader.GetInt32(3);
                        movieListDTOs.Add(movieListDTO);
                    }
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
            return movieListDTOs;
        }

        public void Update(MovieListDTO movieListDTO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM MovieList";
                    query += " UPDATE MovieList SET Name = @Name";
                    query += " , MovieCount = @MovieCount";
                    query += " , UserId = @UserId";
                    query += " Where Id = @Id";
                    SqlCommand updateMovieListCommand = new SqlCommand(query, conn);
                    conn.Open();
                    updateMovieListCommand.Parameters.AddWithValue("@Name", movieListDTO.Name);
                    updateMovieListCommand.Parameters.AddWithValue("@MovieCount", movieListDTO.MovieCount);
                    updateMovieListCommand.Parameters.AddWithValue("@UserId", movieListDTO.UserId);
                    updateMovieListCommand.Parameters.AddWithValue("@Id", movieListDTO.Id);
                    updateMovieListCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public List<int> GetAllMovieListMoviesIDs(int movieListId)
        {
            List<int> movieIds = new List<int>();
            try
            {
                //SELECT Id, etc, etc, etc FROM "TableName"
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM MovieList_Movies WHERE MovieList_Id = @MovieList_Id";
                    SqlCommand getMovieListMovies = new SqlCommand(query, conn);
                    getMovieListMovies.Parameters.AddWithValue("@MovieList_Id", movieListId);
                    conn.Open();
                    var reader = getMovieListMovies.ExecuteReader();
                    while (reader.Read())
                    {
                        int movieId = reader.GetInt32(2);
                        movieIds.Add(movieId);
                    }
                }                          
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }

            return movieIds;
        }
        //deletes a movie from the movie list which it is in
        public void RemoveMovieFromList(int movieListId, int movieId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE * FROM MovieList_Movies WHERE (MovieList_Id = @MovieList_Id) AND Movie_Id = @Movie_Id";
                    SqlCommand deleteMovieFromListCommand = new SqlCommand(query, conn);
                    deleteMovieFromListCommand.Parameters.AddWithValue("@MovieList_Id", movieListId);
                    deleteMovieFromListCommand.Parameters.AddWithValue("@Movie_Id", movieId);
                    conn.Open();
                    deleteMovieFromListCommand.ExecuteNonQuery();
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public void RemoveMovieFromAllLists(int movieId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE * FROM MovieList_Movies WHERE MovieList_Id = @MovieList_Id";
                    SqlCommand deleteMovieFromAllListCommand = new SqlCommand(query, conn);
                    deleteMovieFromAllListCommand.Parameters.AddWithValue("@Movie_Id", movieId);
                    conn.Open();
                    deleteMovieFromAllListCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
