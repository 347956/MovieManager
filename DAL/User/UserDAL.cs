using ContractLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class UserDAL : IUserDAL, IUserCollectionDAL
    {
        string connectionString = "Server=mssql.fhict.local;Database=dbi347956;User Id =dbi347956;Password=Teun1701!";
        public int CreateUser(UserDTO userDTO)
        {
            int Id = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO UserTest (UName, FName, LName, Admin, Password)";
                    query += " VALUES (@UName, @FName, @LName, @Admin, @Password)";
                    query += " SELECT CAST (scope_identity() AS Int)";
                    SqlCommand createUserCommand = new SqlCommand(query, conn);
                    createUserCommand.Parameters.AddWithValue("@UName", userDTO.UName);
                    createUserCommand.Parameters.AddWithValue("@FNAme", userDTO.FName);
                    createUserCommand.Parameters.AddWithValue("@LName", userDTO.LName);
                    createUserCommand.Parameters.AddWithValue("@Admin", userDTO.Admin);
                    createUserCommand.Parameters.AddWithValue("@Password", userDTO.Password);
                    conn.Open();
                    Id = Convert.ToInt32(createUserCommand.ExecuteScalar());
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e);
            }
            return Id;
        }

        public void DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetALLUser()
        {
            List<UserDTO> userDTOs = new List<UserDTO>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM UserTest";
                    SqlCommand getAllUsers = new SqlCommand(query, conn);
                    conn.Open();
                    var reader = getAllUsers.ExecuteReader();
                    while (reader.Read())
                    {
                        UserDTO userDTO = new UserDTO();
                        userDTO.Id = reader.GetInt32(0);
                        userDTO.UName = reader.GetString(1);
                        userDTO.FName = reader.GetString(2);
                        userDTO.LName = reader.GetString(3);
                        userDTO.Admin = reader.GetBoolean(4);
                        userDTO.Password = reader.GetString(5);
                        userDTOs.Add(userDTO);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return userDTOs;
        }

        public UserDTO GetUser(int Id)
        {
            UserDTO userDTO = new UserDTO();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM UserTest WHERE Id = @Id";
                    SqlCommand getUserCommand = new SqlCommand(query, conn);
                    getUserCommand.Parameters.AddWithValue("@Id", Id);
                    conn.Open();
                    getUserCommand.ExecuteNonQuery();
                    var reader = getUserCommand.ExecuteReader();
                    reader.Read();
                    userDTO.Id = reader.GetInt32(0);
                    userDTO.UName = reader.GetString(1);
                    userDTO.FName = reader.GetString(2);
                    userDTO.LName = reader.GetString(3);
                    userDTO.Admin = reader.GetBoolean(4);
                    userDTO.Password = reader.GetString(5);
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return userDTO;
        }
        public bool ValidateByUName(string UName)
        {
            bool valid = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM UserTest WHERE UName = @UName";
                    SqlCommand getUserCommand = new SqlCommand(query, conn);
                    getUserCommand.Parameters.AddWithValue("@UName", UName);
                    conn.Open();
                    getUserCommand.ExecuteNonQuery();
                    var reader = getUserCommand.ExecuteReader();
                    if(reader.Read())
                    {
                        valid = false;
                    }
                    else
                    {
                        valid = true;
                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return valid;
        }

        public void UpdateUser(UserDTO userDTO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM UserTest";
                    query += " UPDATE UserTest SET FName = @FName";
                    query += " , LName = @LName";
                    query += " , Password = @Password";
                    query += " , Admin = @Admin";
                    query += " Where Id = @Id";
                    SqlCommand updateUserCommand = new SqlCommand(query, conn);
                    conn.Open();
                    updateUserCommand.Parameters.AddWithValue("@FName", userDTO.FName);
                    updateUserCommand.Parameters.AddWithValue("@LName", userDTO.LName);
                    updateUserCommand.Parameters.AddWithValue("@Password", userDTO.Password);
                    updateUserCommand.Parameters.AddWithValue("@Admin", userDTO.Admin);
                    updateUserCommand.Parameters.AddWithValue("@Id", userDTO.Id);
                    updateUserCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        public UserDTO GetUserByUName(string Uname)
        {
            UserDTO userDTO = new UserDTO();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM UserTest WHERE UName = @UName";
                    SqlCommand getUserCommand = new SqlCommand(query, conn);
                    getUserCommand.Parameters.AddWithValue("@UName", Uname);
                    conn.Open();
                    getUserCommand.ExecuteNonQuery();
                    SqlDataReader reader = getUserCommand.ExecuteReader();
                    if(reader.Read())
                    {
                        userDTO.Id = reader.GetInt32(0);
                        userDTO.UName = reader.GetString(1);
                        userDTO.FName = reader.GetString(2);
                        userDTO.LName = reader.GetString(3);
                        userDTO.Admin = reader.GetBoolean(4);
                        userDTO.Password = reader.GetString(5);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return userDTO;
        }

        public int GetUserIdByUName(string UName)
        {
            int UserId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT UserTest.Id AS UID FROM UserTest WHERE UName = @UName";
                    SqlCommand getUserIdCommand = new SqlCommand(query, conn);
                    getUserIdCommand.Parameters.AddWithValue("@UName", UName);
                    conn.Open();
                    getUserIdCommand.ExecuteNonQuery();
                    SqlDataReader reader = getUserIdCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        UserId = Convert.ToInt32(reader["UID"]);
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return UserId;
        }
    }
}
