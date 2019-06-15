using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBird.UI.Areas.AppUser.Models.VM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "User Name Eror")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Eror!")]
        public string Password { get; set; }
    }
}