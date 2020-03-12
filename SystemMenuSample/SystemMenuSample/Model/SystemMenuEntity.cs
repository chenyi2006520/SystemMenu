using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SystemMenuSample
{
    /// <summary>
    /// 菜单表
    /// </summary>
    [Table("bee_system_menu")]
    public class SystemMenuEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Required]
        public long id { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        [Required]
        public long pid { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string title { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string href { get; set; } 

        /// <summary>
        /// 链接
        /// </summary>
        public string target { get; set; }
        

        /// <summary>
        /// 序号
        /// </summary>
        public int sort { get; set; }

        /// <summary>
        /// 是否菜单
        /// </summary>
        public bool status { get; set; } 
         
    }
}
