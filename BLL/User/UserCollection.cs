using ContractLayer;
using FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    class UserCollection
    {
        IUserCollectionDAL userCollectionDAL = FactoryUserDAL.CreateUserCollectionDAL();
        public void CreateUser(UserDTO userDTO)
        {
            userCollectionDAL.CreateUser(userDTO);
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
    }
}
