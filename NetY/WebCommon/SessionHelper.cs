using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetY.WebCommon
{
    public class SessionHelper: BaseController
    {
        public bool IfExitSession()
        {
            byte[] result;
            HttpContext.Session.TryGetValue("CurrentUser", out result);

            if (result == null)
            {
                return false;
            }

            return true;
        }
    }
}
