using SmartParking.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.DAL
{
    public class UserDal : WebDataAccess, IUserDal
    {
        /// <summary>
        /// 获取所有的用户
        /// </summary>
        /// <returns></returns>
        public Task<string> GetAll()
        {
            // 服务接口
            return this.GetDatas($"{domain}user/all");
        }

        public Task<string> GetRolesByUserId(int userId)
        {
            return this.GetDatas($"{domain}user/roles/{userId}");
        }

        public Task ResetPassword(string userId)
        {
            Dictionary<string, HttpContent> param = new Dictionary<string, HttpContent>();
            param.Add("userId", new StringContent(userId));

            return this.PostDatas($"{domain}user/resetpwd", param); // 这里拿的是服务器UserController的内容
        }

        public Task SaveUser(string data)
        {
            StringContent content = new StringContent(data);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return this.PostDatas($"{domain}user/save", content);
        }
    }
}
