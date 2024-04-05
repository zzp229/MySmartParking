using SmartParking.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.IBLL
{
    public interface IUserBLL
    {
        Task<List<UserEntity>> GetAll();

        Task<List<RoleEntity>> GetRolesByUserId(int userId);

        Task ResetPassword(string userId);
        Task SaveUser(UserEntity userEntity);
    }
}
