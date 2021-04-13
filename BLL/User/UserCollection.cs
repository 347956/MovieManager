using ContractLayer;
using FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class UserCollection
    {
        IUserCollectionDAL userCollectionDAL = FactoryUserDAL.CreateUserCollectionDAL();
        public bool CreateUser(UserDTO userDTO)
        {
            bool userCreated;
            if(ValidateUser(userDTO) == true)
            {
                userCollectionDAL.CreateUser(userDTO);
                userCreated = true;
            }
            else
            {
                userCreated = false;
            }
            return userCreated;
        }
        public User GetUser(int Id)
        {
            User user = new User(userCollectionDAL.GetUser(Id));
            return user;
        }
        public List<User> GetAllUser()
        {
            List<User> users = new List<User>();
            foreach(UserDTO userDTO in userCollectionDAL.GetALLUser())
            {
                User user = new User(userDTO);
                users.Add(user);
            }
            return users;
        }
        public void DeleteUser(int Id)
        {
            userCollectionDAL.DeleteUser(Id);
        }
        //checks if a username is already present in the database and returns a bool
        private bool ValidateUser(UserDTO userDTO)
        {
            bool valid;
            if(userCollectionDAL.GetUserByUName(userDTO.UName) == null)
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return valid;
        }
    }
}
