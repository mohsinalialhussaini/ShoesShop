using JOOTASHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JOOTASHOP.Controllers
{
    public class HomeController : Controller
    {
        public static string name="User";
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult newarrivals()
        {
            return View();
        }

        public ActionResult womens()
        {
            return View();
        }

        Manager.DatabaseOperations DB = new Manager.DatabaseOperations();
        // GET: Mens
        menTable css = new menTable();
      

        public ActionResult mens(int opt = 0, string val="")
        {
            searchModel mdl = new searchModel();
            if (mdl!=null)
            {

                val = mdl.searchVal;
            }
            Manager.currrentStatus.option = opt;
            List<productTable> cst = DB.readManData(opt);


            return View(cst);
        }
       

        public ActionResult kids()
        {
            return View();
        }

        public ActionResult SearchBar(string val)
        {
            return View();
        }

        public ActionResult sale()
        {
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }


    }
}