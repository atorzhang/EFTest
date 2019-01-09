using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Table
{
    public class EntityBase
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        [StringLength(32)]
        public string CreateUser { get; set; }

        /// <summary>
        /// 状态0-删除，1-正常，2-禁用，3-待审核
        /// </summary>
        [Display(Name = "状态0-逻辑删除，1-正常，2-禁用,...")]
        public virtual int? Status { get; set; } = 2;

        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int? Sort { get; set; } = 0;

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [StringLength(200)]
        public string Remark { get; set; } = "";
    }
}
