﻿using System;
using ContractLayer;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DAL
{
    public class MovieDAL : IMovieDAL, IMovieCollectionDAL
    {
        string connectionString = ConnStringClass.GetConnectionString();
        public int CreateMovie(MovieDTO movieDTO)
        {
            int id = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO MovieTest (Name, Genre, Genre2, Date, Watched)";
                    query += " VALUES (@Name, @Genre, @Genre2, @Date, @Watched)";
                    query += " SELECT CAST (scope_identity() AS int)";
                    SqlCommand createMovieCommand = new SqlCommand(query, conn);                    
                    createMovieCommand.Parameters.AddWithValue("@Name", movieDTO.Name);
                    createMovieCommand.Parameters.AddWithValue("@Genre", movieDTO.Genre);
                    createMovieCommand.Parameters.AddWithValue("@Genre2", movieDTO.GenreTwo);
                    createMovieCommand.Parameters.AddWithValue("@Date", movieDTO.Date);
                    createMovieCommand.Parameters.AddWithValue("@Watched", movieDTO.Watched);
                    conn.Open();
                    id = Convert.ToInt32(createMovieCommand.ExecuteScalar());
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }

            return id;
        }

        public void DeleteMovie(int ID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE * FROM MovieTest WHERE Id = @Id";
                    SqlCommand deleteMovieCommand = new SqlCommand(query, conn);
                    deleteMovieCommand.Parameters.AddWithValue("@Id", ID);
                    conn.Open();
                    deleteMovieCommand.ExecuteNonQuery();
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public List<MovieDTO> GetALLMovies()
        {
            List<MovieDTO> movieDTOs = new List<MovieDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM MovieTest";
                    SqlCommand getAllMovies = new SqlCommand(query, conn);
                    conn.Open();
                    var reader = getAllMovies.ExecuteReader();
                    while (reader.Read())
                    {
                        MovieDTO movieDTO = new MovieDTO();
                        movieDTO.ID = reader.GetInt32(0);
                        movieDTO.Name = reader.GetString(1);
                        movieDTO.Genre = reader.GetString(2);
                        movieDTO.GenreTwo = reader.GetString(3);
                        movieDTO.Date = reader.GetString(4);
                        movieDTO.Watched = reader.GetBoolean(5);
                        movieDTOs.Add(movieDTO);
                    }
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
            return movieDTOs;
        }

        public MovieDTO GetMovie(int ID)
        {
            MovieDTO movieDTO = new MovieDTO();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM MovieTest WHERE Id = @Id";
                    SqlCommand getMovieCommand = new SqlCommand(query, conn);
                    getMovieCommand.Parameters.AddWithValue("@Id", ID);
                    conn.Open();
                    getMovieCommand.ExecuteNonQuery();
                    SqlDataReader reader = getMovieCommand.ExecuteReader();
                    reader.Read();
                    movieDTO.ID = reader.GetInt32(0);
                    movieDTO.Name = reader.GetString(1);
                    movieDTO.Genre = reader.GetString(2);
                    movieDTO.GenreTwo = reader.GetString(3);
                    movieDTO.Date = reader.GetString(4);
                    movieDTO.Watched = reader.GetBoolean(5);
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
            return movieDTO;
        }

        public void Update(MovieDTO movieDTO, int ID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM MovieTest";
                    query += " UPDATE MovieTest SET Name = @Name";
                    query += " , Genre = @Genre";
                    query += " , Genre2 = @Genre2";
                    query += " , Date = @Date";
                    query += " , Watched = @Watched";
                    query += " Where Id = @Id";
                    SqlCommand updateMovieCommand = new SqlCommand(query, conn);
                    conn.Open();
                    updateMovieCommand.Parameters.AddWithValue("@Name", movieDTO.Name);
                    updateMovieCommand.Parameters.AddWithValue("@Genre", movieDTO.Genre);
                    updateMovieCommand.Parameters.AddWithValue("@Genre2", movieDTO.GenreTwo);
                    updateMovieCommand.Parameters.AddWithValue("@Date", movieDTO.Date);
                    updateMovieCommand.Parameters.AddWithValue("@Watched", movieDTO.Watched);
                    updateMovieCommand.Parameters.AddWithValue("@Id", ID);
                    updateMovieCommand.ExecuteNonQuery();
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
