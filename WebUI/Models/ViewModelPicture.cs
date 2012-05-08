using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ViewModelPicture
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public string Description { get; set; }

        public int Product_ProductId { get; set; }
    }
}