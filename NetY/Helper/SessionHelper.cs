using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NetY.Helper
{
    public class SessionHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        public string GetCurrentUser()
        {
            try
            {
                var value = _session.GetString("CurrentUser");

                if (string.IsNullOrEmpty(value))
                {
                    value = string.Empty;
                }

                return value;
            }
            catch (Exception ee)
            {
                return null;
            }
        }

        //public static string CurrentUser()
        //{
        //    return GetCurrentUser();
        //}

        public void Set()
        {
            _session.SetString("CurrentUser", "123456");
        }

        public void Get()
        {
            string code = _session.GetString("CurrentUser");
        }
    }
}
