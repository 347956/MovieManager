using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IUserCollectionDAL
    {
        void CreateUser(UserDTO userDTO);
        UserDTO GetUser(int id);
        List<UserDTO> GetALLUser();
        void DeleteUser(int id);
    }
}
