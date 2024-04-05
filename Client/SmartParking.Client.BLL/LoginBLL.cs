using SmartParking.Client.Entity;
using SmartParking.Client.IBLL;
using SmartParking.Client.IDAL;
using System;
using System.Threading.Tasks;

namespace SmartParking.Client.BLL
{
    public class LoginBLL : ILoginBLL
    {
        ILoginDal _loginDal;

        public LoginBLL(ILoginDal loginDal)
        {
            this._loginDal = loginDal;
        }

        public async Task<bool> Login(string username, string password)
        {
            // Json串
            var loginStr = await _loginDal.Login(username, password);
            // 用户信息的反序列化（反序列化为对象）
            UserEntity userEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<UserEntity>(loginStr);

            if (userEntity != null)
            {
                GlobalEntity.CurrentUserInfo = userEntity;  // 记录当前登录的用户
                return true;
            }

            return false;
        }
    }
}
