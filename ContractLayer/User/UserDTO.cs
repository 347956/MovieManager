using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public class UserDTO
    {
        public string UName { get; set; }
        public string FName { get;set; }
        public string LName { get; set; }
        public bool Admin { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
