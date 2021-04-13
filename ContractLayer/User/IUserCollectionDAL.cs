using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IUserCollectionDAL
    {
        int CreateUser(UserDTO userDTO);
        UserDTO GetUser(int Id);
        List<UserDTO> GetALLUser();
        void DeleteUser(int Id);
        UserDTO GetUserByUName(string UName);
    }
}
