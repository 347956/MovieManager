using ContractLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UserDAL : IUserDAL, IUserCollectionDAL
    {
        public void CreateUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetALLUser()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public UserDTO UpdateUser(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
