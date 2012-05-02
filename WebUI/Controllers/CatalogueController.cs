using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class CatalogueController : BaseController
    {
        //
        // GET: /Catalogue/

        public ActionResult Index()
        {
            return View();
        }

    }
}
