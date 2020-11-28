using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace WebApplication5.Filter
{
    public class Security:ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["CUSTOMER"] == null
                && !(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Home"))
            {
                filterContext.Result = new RedirectResult("/HomePage/Index");
                return;
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }

        }
    }
}