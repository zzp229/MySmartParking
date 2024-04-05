using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartParking.Server.Models
{
    [Table("sys_user_info")]
    public class SysUserInfo
    {
        [Key]   // 主键
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   // 自动生成
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("user_icon")]
        public string UserIcon { get; set; }

        [NotMapped] // 不会映射到数据库表
        public List<MenuInfo> Menus { get; set; }
    }
}
