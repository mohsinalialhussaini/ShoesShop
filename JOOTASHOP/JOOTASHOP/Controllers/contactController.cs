using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOOTASHOP.Models;

namespace JOOTASHOP.Controllers
{
    public class contactController : Controller
    {
        // GET: contact
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact _contact)
        {
            if (ModelState.IsValid)
            {
                string Message = "Name: " + _contact.name + "\nEmail: " + _contact.email + "\nContact: " + _contact.phone + "\nMessage: " + _contact.message;
                Manager.sendMail mail = new Manager.sendMail();
                int A=mail.mail("Email From User", Message);

                if (A==1)
                {
                    ViewBag.Message = "Message Sent Successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = "Sending Failed";
                  
                }
            }

            return View();
        }
    }
}