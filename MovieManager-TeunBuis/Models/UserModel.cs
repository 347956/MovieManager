using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager_TeunBuis
{
    public class UserModel
    {
        [Required]
        public string UName { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        public bool Admin { get; set; }
        public int Id { get; set; }
    }
}
