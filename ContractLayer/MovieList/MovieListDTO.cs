using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public class MovieListDTO
    {
        public string Name { get; set; }
        public int MovieCount { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
