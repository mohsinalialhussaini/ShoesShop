using JOOTASHOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JOOTASHOP.Controllers
{
    public class shoppingcartController : Controller
    {
        Manager.DatabaseOperations db = new Manager.DatabaseOperations();
        // GET: shoppingcart
        public ActionResult Index()
        {
            return View();
        }
        Manager.DatabaseOperations DB = new Manager.DatabaseOperations();

        menTable css = new menTable();
        public ActionResult ViewCart()
        {
            List<menTable> cst = DB.readCart();


            return View(cst);
        }


      public ActionResult deleteCart(int StudID)
        {
            db.deleteDAtaFromCart(StudID);

            return RedirectToAction("ViewCart", "shoppingcart");
        }

    

        public ActionResult AddtoCard(int _ID)
        {
            db.Addtocart(_ID);
            return RedirectToAction("mens", "Home", new { opt = 1 });


        }
    }
}