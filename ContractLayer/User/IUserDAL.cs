using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IUserDAL
    {
        void UpdateUser(UserDTO userDTO);
    }
}
