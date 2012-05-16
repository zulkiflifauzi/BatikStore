using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ViewModelProduct 
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [DisplayName("Size")]
        public Nullable<int> Size_SizeId { get; set; }

        [DisplayName("Model")]
        public Nullable<int> Model_ModelId { get; set; }

        [DisplayName("Type")]
        public Nullable<int> Type_TypeId { get; set; }

        [DisplayName("Origin")]
        public Nullable<int> Origin_OriginId { get; set; }

        public bool Promoted { get; set; }

        public DateTime DateEntered { get; set; }

        public string SizeName { get; set; }

        public string ModelName { get; set; }

        public string TypeName { get; set; }

        public string OriginName { get; set; }

        public string Date { get; set; }

        private List<ViewModelPicture> _pictures = new List<ViewModelPicture>();

        public List<ViewModelPicture> Pictures
        {
            get { return _pictures; }
            set { _pictures = value; }
        }
    }
}