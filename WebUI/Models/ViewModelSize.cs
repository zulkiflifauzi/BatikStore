using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ViewModelSize
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}