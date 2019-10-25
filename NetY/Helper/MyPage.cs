using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetY.Helper
{
    public class MyPage : PageModel
    {
        public bool IsLogin
        {
            get
            {
                string userId = null;
                //从sessin中获取UserId对应的用户信息来判断用户是否登陆
                if (HttpContext.Session.TryGetValue("CurrentUser", out byte[] bytes))
                {
                    userId = Encoding.UTF8.GetString(bytes);
                }

                return !string.IsNullOrWhiteSpace(userId);
            }
        }
    }
}
