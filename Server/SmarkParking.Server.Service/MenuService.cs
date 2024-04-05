using Microsoft.EntityFrameworkCore;
using SmarkParking.Server.IService;
using SmartParking.Server.IEFContext;
using SmartParking.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmarkParking.Server.Service
{
    public class MenuService : ServiceBase, IMenuService
    {
        // 因为要调用父类的有参构造函数
        public MenuService(IEFContext eFContext) : base(eFContext)
        {

        }

        public List<MenuInfo> GetAllMenus()
        {
            return (from menu in Context.Set<MenuInfo>()
                    where menu.State == 1
                    select menu).ToList();
        }

        public List<MenuInfo> GetMenusByRoleId(int roleId)
        {
            // 获取所有权限
            var roles = (from role in Context.Set<RoleInfo>()
                         where role.RoleId == roleId && role.state == 1
                         select role.RoleId).ToList();

            var query = from menu in Context.Set<MenuInfo>()
                        join role_menu in Context.Set<RoleMenu>()
                        on menu.MenuId equals role_menu.MenuId
                        where roles.Contains(role_menu.RoleId) && menu.State == 1
                        select menu;

            return query.Distinct().ToList();
        }

        public List<MenuInfo> GetMenusByUserId(int userId)
        {
            // 获取所有权限
            var roles = (from ur in Context.Set<UserRole>()
                         join role in Context.Set<RoleInfo>() on ur.RoleId equals role.RoleId
                         where ur.UserId == userId && role.state == 1
                         select ur.RoleId).ToList();

            // 菜单的去重
            var query = from menu in Context.Set<MenuInfo>()
                        join role_menu in Context.Set<RoleMenu>()
                        on menu.MenuId equals role_menu.MenuId
                        where roles.Contains(role_menu.RoleId) && menu.State == 1
                        select menu;

            return query.Distinct().ToList();
        }

        public void SaveMenu(string data)
        {
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<MenuInfo>(data);

            if (value.MenuId == 0)
            {
                var index = Context.Set<MenuInfo>().Max(i => i.Index);
                value.Index = index + 1;
            }
            value.State = 1;

            Context.Entry(value).State = value.MenuId == 0 ?
                EntityState.Added :
                EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
