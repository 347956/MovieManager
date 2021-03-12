using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager_TeunBuis.Models
{
    public class MovieModel
    {
        public string Name { get;set; }
        public string Genre { get; set; }
        public string GenreTWo { get; set; }
        public string Date { get; set; }
        public bool Watched { get; set; }
        public int ID { get; set; }
    }
}
