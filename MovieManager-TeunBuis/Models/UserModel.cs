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
        [Required]
        [DataType (DataType.Password)]
        [StringLength(100, ErrorMessage = "The Password {0} has to be at least {2} characters long!", MinimumLength = 4)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Passwords dont match!")]
        public string PasswordConfirm { get; set; }

        public bool Admin { get; set; }
        public int Id { get; set; }
    }
}
