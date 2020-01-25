using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JOOTASHOP.Controllers
{
    public class SearchBarController : Controller
    {
        // GET: SearchBar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult search(string val)
        {

            return View();
        }
    }
}