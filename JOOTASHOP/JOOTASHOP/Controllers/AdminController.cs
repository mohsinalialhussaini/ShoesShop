 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using JOOTASHOP.Models;

namespace JOOTASHOP.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(string _name)
        {
            ViewBag.Message = _name;
            return View();
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
           
            var items = dbo.getCatagories();
            if (items!=null)
            {
                // ViewBag.data = items;
                productTable.catTempLint = items;
            }
            
            return View();
        }

        Manager.DatabaseOperations dbo = new Manager.DatabaseOperations();
        [HttpPost]
        public ActionResult AddProduct(productTable table)
        {

            string fileName = Path.GetFileNameWithoutExtension(table.ImageFile.FileName);
            string extension = Path.GetExtension(table.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;

            table.imagePath = "~/Content/ProductImages/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/ProductImages/"), fileName);

            table.ImageFile.SaveAs(fileName);
            dbo.AddDAta(table);
            ModelState.Clear();
            //  return View();
            ViewBag.Message = "OperationSuccessfull";
            return RedirectToAction("AddProduct", "Admin");
        }

      
        public ActionResult viewItems(int opt=0)
        {
            return RedirectToAction("viewManProduct", "Mens");
            //Models.viewProductModel adm = new Models.viewProductModel();
            //List<string> pth = adm.filePath;
            //return View(pth);



        }

        [HttpGet]
        public ActionResult AddNewCatagory()
        {
            
            ViewBag.Message = "";
            return View();
        }

        [HttpPost]
        public ActionResult AddNewCatagory(catagoryTable catTable)
        {
            if (ModelState.IsValid)
            {
                Manager.DatabaseOperations DB = new Manager.DatabaseOperations();
                if(DB.AddCatagory(catTable.catagoryName)>0)
                {
                    
                    ViewBag.Message = "Operation Successfull";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = "Operation Failed";
                }

               
            }
                return View();
        }

        public ActionResult manageUser()
        {
            return View();
        }


    }
}