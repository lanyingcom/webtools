using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetY.WebCommon
{
 
    public abstract class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            byte[] result;
            filterContext.HttpContext.Session.TryGetValue("CurrentUser", out result);

            if (result == null)
            {
                filterContext.Result = new RedirectResult("/Home/Login");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
