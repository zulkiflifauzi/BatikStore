using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ViewModelLogin
    {
        [Required]
        [RegularExpression("^[0-9a-zA-Z]+([0-9a-zA-Z]*[-._+])*[0-9a-zA-Z]+@[0-9a-zA-Z]+([-.][0-9a-zA-Z]+)*([0-9a-zA-Z]*[.])[a-zA-Z]{2,6}$", ErrorMessage="Invalid Email format")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}