using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class 共用的ActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = "歡迎光臨";
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string timer = DateTime.Now.ToString();
            filterContext.Controller.ViewBag.Timer = timer;
            base.OnActionExecuted(filterContext);
        }
    }
}