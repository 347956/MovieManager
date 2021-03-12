using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public class MovieDTO
    {
        //properties
        public string  Name { get; set; }
        public string Genre { get; set; }
        public string GenreTwo { get; set; }
        public string Date { get; set; }
        public bool Watched { get; set; }
        public int ID { get; set; }
    }
}
