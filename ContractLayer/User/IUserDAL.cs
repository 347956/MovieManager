using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IUserDAL
    {
        UserDTO UpdateUser(UserDTO userDTO);
    }
}
