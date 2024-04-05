using SmartParking.Client.Entity;
using SmartParking.Client.IBLL;
using SmartParking.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.BLL
{
    /// <summary>
    /// DAL中获取的数据在bll中反序列化回给对象
    /// </summary>
    public class UserBLL : IUserBLL
    {
        IUserDal _userDal;

        public UserBLL(IUserDal userDal)
        {
            this._userDal = userDal;
        }
        public async Task<List<UserEntity>> GetAll()
        {
            string usersStr = await _userDal.GetAll();   // 这个拿到的是所有的用户
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserEntity>>(usersStr);   // 将json反序列化回对象
        }

        public async Task<List<RoleEntity>> GetRolesByUserId(int userId)
        {
            var rolesStr = await _userDal.GetRolesByUserId(userId);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoleEntity>>(rolesStr);
        }

        public Task ResetPassword(string userId)
        {
            return _userDal.ResetPassword(userId);
        }

        public Task SaveUser(UserEntity userEntity)
        {
            return _userDal.SaveUser(Newtonsoft.Json.JsonConvert.SerializeObject(userEntity));
        }
    }
}
