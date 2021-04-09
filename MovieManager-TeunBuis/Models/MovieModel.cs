using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager_TeunBuis.Models
{
    public class MovieModel
    {
        [Required]
        public string Name { get;set; }
        [Required]
        public string Genre { get; set; }
        public string GenreTwo { get; set; }
        public string Date { get; set; }
        [Required]
        public bool Watched { get; set; }
        public int ID { get; set; }
    }
}
