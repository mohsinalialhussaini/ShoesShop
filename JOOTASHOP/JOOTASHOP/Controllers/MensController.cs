using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JOOTASHOP.Models;
namespace JOOTASHOP.Controllers
{
    public class MensController : Controller
    {
        Manager.DatabaseOperations DB = new Manager.DatabaseOperations();
        // GET: Mens
       menTable  css = new menTable();
        public ActionResult viewManProduct(int opt=0)
        {
            Manager.currrentStatus.option = opt;
            List<productTable> cst = DB.readManData(opt);


            return View(cst);
        }

        public ActionResult DeleteProduct(int StudID)
        {
            DB.deleteProduct(StudID);
            return RedirectToAction("viewManProduct","Mens",new {opt= Manager.currrentStatus.option });

        }
        

    }
}