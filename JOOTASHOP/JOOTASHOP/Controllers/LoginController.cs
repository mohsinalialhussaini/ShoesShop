using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOOTASHOP.Models;
namespace JOOTASHOP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "";
            return View();
           
        }

        Manager.loginManager LgM = new Manager.loginManager();

        [HttpPost]
        public ActionResult Index(loginModel _loginModel)
        {
          int ID  =   LgM.CheckLogin(_loginModel);
            LgM.getUserData(ID);
            if (ModelState.IsValid)
            {
                


                    if (Models.AdminData.name != null)
                    {

                        ViewBag.Message = "Admin : " + Models.AdminData.name;
                        return RedirectToAction("Index", "Admin", new { _name = Models.AdminData.name });

                    }

                   
                
                else
                {
                    ViewBag.message = "Invalid Login";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Regestration()
        {
            ViewBag.Message = "";

            return View();
        }

        Manager.RegestrationManager manager = new Manager.RegestrationManager();

        [HttpPost]
        public ActionResult Regestration(RegestrationModel _regestrationModel)
        {
            if (ModelState.IsValid)
            {


                int a = manager.AddDAta(_regestrationModel);
                if (a > 0)
                {
                    ViewBag.Message = "Successfull";
                    return RedirectToAction("Index", "Login");

                }
                else
                {

                    ViewBag.Message = "Oops! Error";
                }
            }
            else
            {
                ViewBag.Message = "Incomplete Form";
            }

            return View();
        }


    }
}