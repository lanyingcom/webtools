using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetY.Helper
{
    public class BaseController : Controller
    {
        public string GetLoginUser()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("CurrentUser")))
            {
                return HttpContext.Session.GetString("CurrentUser");
            }

            return null;
        }

        /// <summary>
        ///判断是否登录
        /// </summary>
        /// <returns></returns>
        public bool IsLogin()
        {
            HttpContext.Session.SetString("CurrentUser", "123456");

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("CurrentUser")))
            {
                return true;
            }

            return false;
        }
    }
}
