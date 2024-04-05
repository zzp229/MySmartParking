using Microsoft.EntityFrameworkCore;
using SmartParking.Server.Models;
using System;

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
            //base.OnConfiguring(optionsBuilder);
        }

        public DbSet<SysUserInfo> SysUserInfo { get; set; }
    }
}
