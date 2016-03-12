using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MVC5Course.Controllers
{
    public class EFController : BaseController
    {
        FabricsEntities db = new FabricsEntities();
        // GET: EF
        public ActionResult Index(bool? IsActive , string keyword)
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

            //SaveChanges();
            //var pkey = product.ProductId;
            //var data = db.Product.ToList();
            //var data = db.Product.Where(p => p.ProductId == pkey).ToList();
            var data = db.Product.OrderByDescending(p => p.ProductId).AsQueryable();

            if (IsActive.HasValue)
            {
                data = data.Where(p => p.Active == IsActive);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.Where(p => p.ProductName.Contains(keyword));
            }

            //foreach (var item in data)
            //{
            //    item.Price = item.Price + 1;
            //}
            //SaveChanges();

            return View(data);
        }

        private void SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var allErrors = new List<string>();
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {

                    foreach (DbValidationError err in item.ValidationErrors)
                    {
                        allErrors.Add(err.ErrorMessage);
                        string message = "錯誤訊息：" + err.ErrorMessage;
                        throw new Exception(message);
                    }
                }
                ViewBag.Errors = allErrors;
                //throw;
            }
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
            //foreach (var item in data.OrderLine.ToList())
            //{
            //    db.OrderLine.Remove(item);
            //}

            db.OrderLine.RemoveRange(data.OrderLine);

            db.Product.Remove(data);
            SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult QueryPlain()
        {
            //var data = db.Product
            //    .Include("OrderLine")
            //    .OrderByDescending(p => p.ProductId)
            //    .AsQueryable();
            var data = db.Product
                .Include(t => t.OrderLine)
                .OrderBy(p => p.ProductId)
                .ToList();

            //var data = db.Database.SqlQuery<Product>(@"
            //SELECT * FROM dbo.Product WHERE ProductId < @p0
            //",10);

            return View(data);
        }
    }


}