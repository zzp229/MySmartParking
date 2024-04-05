using SmartParking.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmarkParking.Server.IService
{
    public interface IUserService : IServiceBase
    {
        List<RoleInfo> GetRolesByUserId(int userId);

        void ResetPassword(int userId);
        void SaveUser(string data);
    }
}
