using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JOOTASHOP.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmatinForm()
        {
            return View();

        }

        [HttpPost]
        public ActionResult ConfirmatinForm(Models.confirmOrder model)
        {
            if (ModelState.IsValid)
            {
                Manager.DatabaseOperations db = new Manager.DatabaseOperations();
                db.sendConfirmaOrderMail(model);
                return RedirectToAction("sale", "Home");

            }
            return View();

        }
    }
}