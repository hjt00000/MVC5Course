using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class GenderListAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            listItem.Add(new SelectListItem { Text = "男", Value = "M" });
            listItem.Add(new SelectListItem { Text = "女", Value = "F" });
            filterContext.Controller.ViewBag.Gender = new SelectList(listItem, "Value", "Text", "");
            base.OnActionExecuting(filterContext);
        }
    }
}