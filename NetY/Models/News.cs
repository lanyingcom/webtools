using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetY.Models
{
    public class News
    {
        public int ID { get; set; }

        [DisplayName("类别")]
        public int ClassID { get; set; }

        [DisplayName("发布者")]
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("标题")]
        public string Title { get; set; }

        [StringLength(100)]
        [DisplayName("图片")]
        public string PicPath { get; set; }

        [StringLength(1000)]
        [DisplayName("内容")]
        public string InfoContent { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }

        [DisplayName("是否审核")]
        public bool IsPost { get; set; }

        #region 添加

        public IEnumerable<SelectListItem> NewsClasses;

        #endregion
    }
}
