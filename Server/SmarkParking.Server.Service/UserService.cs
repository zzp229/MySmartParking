using IConfiguration;
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
    public class UserService : ServiceBase, IUserService
    {
        private readonly IUtils _utils;

        public UserService(IEFContext eFContext, IUtils utils) : base(eFContext)
        {
            this._utils = utils;
        }

        // 通过EFCore查找
        public List<RoleInfo> GetRolesByUserId(int userId)
        {
            var roles = (from ur in Context.Set<UserRole>()
                         where ur.UserId == userId
                         select ur.RoleId).ToList();

            return (from role in Context.Set<RoleInfo>()
                    where roles.Contains(role.RoleId)
                    select role).ToList();
        }

        public void ResetPassword(int userId)
        {
            Context.Set<SysUserInfo>().Where(u => u.UserId == userId).ToList().ForEach(u => u.Password = _utils.GetMD5Str(_utils.GetMD5Str("123456") + "|" + u.UserName));
            Context.SaveChanges();
        }


        public void SaveUser(string data)
        {
            // 反序列化：用户信息实例
            var value = Newtonsoft.Json.JsonConvert.DeserializeObject<SysUserInfo>(data);

            //value.state = 1;

            // 当新增的时候
            if (value.UserId == 0)
            {
                value.UserIcon = "image/show/temp.jpg";
                value.Password = _utils.GetMD5Str(_utils.GetMD5Str("123456") + "|" + value.UserName);
            }

            Context.Entry(value).State = value.UserId == 0 ?
                EntityState.Added :
                EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
