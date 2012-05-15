using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class ViewModelCatalogue
    {
        private List<ViewModelProduct> _promotedProducts = new List<ViewModelProduct>();

        public List<ViewModelProduct> PromotedProducts
        {
            get { return _promotedProducts; }
            set { _promotedProducts = value; }
        }

        private List<ViewModelProduct> _randomProducts = new List<ViewModelProduct>();

        public List<ViewModelProduct> RandomProducts
        {
            get { return _randomProducts; }
            set { _randomProducts = value; }
        }
    }
}