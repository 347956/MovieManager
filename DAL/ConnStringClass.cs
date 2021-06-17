using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class ConnStringClass
    {
        public static string GetConnectionString()
        {
            return "Server = mssql.fhict.local; Database=dbi347956;User Id = dbi347956; Password=TeunIsCool";
        }
    }
}
