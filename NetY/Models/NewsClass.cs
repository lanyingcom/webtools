using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetY.Models
{
    public class NewsClass
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "类别名称")]
        public string ClassName { get; set; }

        [Display(Name = "父类ID")]
        public int ParentID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "创建日期")]
        public DateTime CreatedTime { get; set; }
    }
}
