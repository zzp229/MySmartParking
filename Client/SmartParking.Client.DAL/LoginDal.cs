using SmartParking.Client.IDAL;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartParking.Client.DAL
{
    public class LoginDal : WebDataAccess, ILoginDal
    {
        public Task<string> Login(string username, string password)
        {
            // 填充好Post请求的form-data
            Dictionary<string, HttpContent> contents = new Dictionary<string, HttpContent>();
            contents.Add("username", new StringContent(username));
            contents.Add("password", new StringContent(password));

            return this.PostDatas($"{domain}user/login", contents);
        }
    }
}
