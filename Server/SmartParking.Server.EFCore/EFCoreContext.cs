using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartParking.Server.Models;
using System;
using System.Globalization;

namespace SmartParking.Server.EFCore
{
    /// <summary>
    /// 这个就是Context
    /// </summary>
    public class EFCoreContext : DbContext
    {
        private string strConn = "server=LAPTOP-61GDB2Q7\\SQLEXPRESS;Database=smartPark_record;Trusted_Connection=True";

        public EFCoreContext()
        {

        }

        public EFCoreContext(string strConn)
        {
            this.strConn = strConn;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(strConn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 联合主键设置
            modelBuilder.Entity<RoleMenu>().HasKey(pk => new { pk.MenuId, pk.RoleId });
            modelBuilder.Entity<UserRole>().HasKey(pk => new { pk.UserId, pk.RoleId });

            // 菜单表中的字体图标值转换
            ValueConverter iconValueConverter = new ValueConverter<string, string>(
                v => string.IsNullOrEmpty(v) ? null : ((int)v.ToCharArray()[0]).ToString("x"),
                v => v == null ? "" : ((char)int.Parse(v, NumberStyles.HexNumber)).ToString());
            modelBuilder.Entity<MenuInfo>().Property(p => p.MenuIcon).HasConversion(iconValueConverter);
        }

        public DbSet<SysUserInfo> SysUserInfo { get; set; }
        public DbSet<MenuInfo> MenuInfo { get; set; }
        public DbSet<RoleInfo> RoleInfo { get; set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
