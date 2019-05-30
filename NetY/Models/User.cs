using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetY.Models
{
    public class User
    {
        public int ID { get; set; }

        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        public string PassWord { get; set; }

        [Display(Name = "邮箱")]
        public string Email { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsPost { get; set; }
    }
}
