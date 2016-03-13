using Microsoft.Web.Mvc;
using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return PartialView("Index");
        }

        public ActionResult FileTest()
        {
            return File(Server.MapPath("~/Content/alphago-logo.png"), "image/png","GoGoGo.png");
        }

        [AjaxOnly]
        public ActionResult JsonTest()
        {
            var db = new FabricsEntities();
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.Take(5);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}