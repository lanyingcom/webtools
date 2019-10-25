using NetY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetY.Helper
{
    public class UserHelper
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// 根据用户名获取userid
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetUserIdByUserName(string username)
        {
            var user = _context.User.FirstOrDefault(m => m.UserName == username);

            if (user == null)
            {
                return 0 ;
            }

            return user.ID;
        }
    }
}
