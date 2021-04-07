using ContractLayer;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryDAL
{
    public static class FactoryUserDAL
    {
        public static IUserDAL CreateUserDAL()
        {
            return new UserDAL();
        }
        public static IUserCollectionDAL CreateUserCollectionDAL()
        {
            return new UserDAL();
        }
    }
}
