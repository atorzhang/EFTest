using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Table
{
    [Table("Sys_User")]
    public class SysUser : EntityBase
    {
        [Key]
        [StringLength(32)]
        public string SysUserId { get; set; }

        [Display(Name = "用户名")]
        [Required]
        [StringLength(32)]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        [StringLength(255)]
        public string Password { get; set; }

        [Display(Name = "真实姓名")]
        [StringLength(32)]
        public string TrueName { get; set; }

        [Display(Name = "昵称")]
        [StringLength(32)]
        public string NikeName { get; set; }

        [Display(Name = "手机号")]
        [StringLength(20)]
        public string Mobile { get; set; }

        [Display(Name = "邮箱")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "QQOpenid")]
        [StringLength(200)]
        public string QQ { get; set; }

        [Display(Name = "微信openid")]
        [StringLength(200)]
        public string WX { get; set; }

        [Display(Name = "头像")]
        [StringLength(255)]
        public string Avatar { get; set; }

        [Display(Name = "性别")]
        [StringLength(1)]
        public string Sex { get; set; }

        [Display(Name = "用户类型")]
        [StringLength(1)]
        public string UserType { get; set; }//0-前台用户，1-管理用户

    }
}
