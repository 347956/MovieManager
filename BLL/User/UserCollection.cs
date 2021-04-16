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
            if(userCollectionDAL.ValidateByUName(userDTO.UName) == true)
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
        public User GetUserByUName(UserDTO userDTO)
        {
            User user = new User(userCollectionDAL.GetUserByUName(userDTO.UName));
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
    }
}
