using ContractLayer;
using FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class User
    {
        public string UName { get; private set; }
        public string FName { get; private set; }
        public string LName { get; private set; }
        public bool Admin { get; private set; }
        public int Id { get; private set; }
        public string Password { get; private set; }

        public User(UserDTO userDTO)
        {
            UName = userDTO.UName;
            FName = userDTO.FName;
            LName = userDTO.LName;
            Admin = userDTO.Admin;
            Password = userDTO.Password;
            Id = userDTO.Id;
        }
        IUserDAL userDAL = FactoryUserDAL.CreateUserDAL();
        public void UpdateUser(UserDTO userDTO)
        {
            userDAL.UpdateUser(userDTO);
        }
    }
}
