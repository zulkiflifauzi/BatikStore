using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;

namespace WebUI.Models
{
    public class ViewModelProduct 
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Description { get; set; }

        public int Zone_ZoneId { get; set; }

        public int Model_ModelId { get; set; }

        public int Type_TypeId { get; set; }

        public int Origin_OriginId { get; set; }
    }
}