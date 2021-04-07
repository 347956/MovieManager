using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public class UserDTO
    {
        public string UName { get; private set; }
        public string FName { get; private set; }
        public string LName { get; private set; }
        public bool Admin { get; private set; }
        public int Id { get; private set; }
    }
}
