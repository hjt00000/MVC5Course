using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        // GET: EF
        public ActionResult Index()
        {
            //var db = new FabricsEntities();
            //var product = new Product()
            //{
            //    ProductName = "BMW",
            //    Price = 20,
            //    Stock = 1,
            //    Active = true
            //};
            //db.Product.Add(product);

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    var allErrors = new List<string>();   
            //    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
            //    {

            //        foreach (DbValidationError err in item.ValidationErrors)
            //        {
            //            allErrors.Add(err.ErrorMessage);
            //            string message = "錯誤訊息："+err.ErrorMessage;

            //        }
            //    }
            //    ViewBag.Errors = allErrors;
            //    //throw;
            //}
            //var pkey = product.ProductId;
            //var data = db.Product.ToList();
            //var data = db.Product.Where(p => p.ProductId == pkey).ToList();
            var data = db.Product.OrderByDescending(p => p.ProductId).Take(5);

            foreach (var item in data)
            {
                item.Price = item.Price + 1;
            }
            db.SaveChanges();

            return View(data);
        }

        public ActionResult Details(int id)
        {
            var data = db.Product.FirstOrDefault(p => p.ProductId == id);
            //var data = db.Product.First(p => p.ProductId == 4000);
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = db.Product.Find(id);
            db.Product.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}