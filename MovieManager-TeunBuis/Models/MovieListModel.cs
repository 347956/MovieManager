using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager_TeunBuis.Models
{
    public class MovieListModel
    {
        [Required]
        public string Name { get; set; }
        public int MovieCount { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> movieIds = new List<int>();
        public List<MovieModel> movieModels = new List<MovieModel>();
    }
}
